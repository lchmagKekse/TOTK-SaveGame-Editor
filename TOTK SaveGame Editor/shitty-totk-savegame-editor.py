import os
import shutil
import struct
import customtkinter as ctk
from customtkinter import filedialog

savefile = bytearray()
path = ""

RUPEE_ADDRESS = 0x2BBA4
HEART_ADDRESS = 0x29A0C
MAX_HEART_ADDRESS = 0x2E884
STAMINA_ADDRESS = 0x34F6C


def LoadSaveFile():
    global savefile
    global path

    path = filedialog.askopenfilename()

    if (os.path.exists(path) == False):
        return
    if (os.path.basename(path) != "progress.sav"):
        return

    shutil.copy(path, f"{os.path.splitext(path)[0]}.backup.sav")
    savefile_path.set(path)

    with open(path, 'rb') as file:
        savefile = bytearray(file.read())

    ReadRupees()
    ReadHearts()
    ReadStamina()


def PatchSave():
    global savefile
    global path

    if (len(savefile) <= 0):
        return

    WriteRupees()
    WriteHearts()
    WriteStamina()

    with open(path, "wb") as file:
        file.write(savefile)


# Rupees
def ReadRupees():
    global savefile
    bytes = savefile[RUPEE_ADDRESS:RUPEE_ADDRESS + 4]
    current_value = int.from_bytes(bytes, byteorder="little")
    rupees.set(value=current_value)


def WriteRupees():
    global savefile
    new_value = rupees.get()
    new_bytes = new_value.to_bytes(length=4, byteorder="little")
    savefile[RUPEE_ADDRESS:RUPEE_ADDRESS + 4] = new_bytes


# Hearts
def ReadHearts():
    global savefile
    bytes = savefile[HEART_ADDRESS:HEART_ADDRESS + 4]
    current_value = int.from_bytes(bytes, byteorder="little") / 4
    hearts.set(value=current_value)


def WriteHearts():
    global savefile
    new_value = hearts.get() * 4
    new_bytes = new_value.to_bytes(length=4, byteorder="little")
    savefile[HEART_ADDRESS:HEART_ADDRESS + 4] = new_bytes
    savefile[MAX_HEART_ADDRESS:MAX_HEART_ADDRESS + 4] = new_bytes


# Stamina
def ReadStamina():
    global savefile
    bytes = savefile[STAMINA_ADDRESS:STAMINA_ADDRESS + 4]
    current_value = struct.unpack('f', bytes)[0]
    stamina.set(value=int(current_value))


def WriteStamina():
    global savefile
    new_value = float(stamina.get())
    new_bytes = struct.pack('f', new_value)
    savefile[STAMINA_ADDRESS:STAMINA_ADDRESS + 4] = new_bytes


# UI Stuff
ctk.set_appearance_mode("dark")
ctk.set_default_color_theme("green")

root = ctk.CTk()
root.title("TOTK | SaveGame Editor")
root.geometry("600x350")
root.resizable(0, 0)

frame = ctk.CTkFrame(master=root)
frame.pack(pady=10, padx=10, fill="both", expand=True)

frame.columnconfigure(0, weight=1)
frame.columnconfigure(1, weight=3)
frame.columnconfigure(2, weight=1)

font_title = ctk.CTkFont(family="Arial", size=24, weight="bold")
font_standard = ctk.CTkFont(family="Arial", size=12, weight="bold")
font_label = ctk.CTkFont(family="Arial", size=16, weight="bold")

# Title
title = ctk.CTkLabel(
    master=frame, text="TOTK SaveGame Editor", font=font_title)
title.grid(columnspan=3, pady=12, padx=10)


# Savefile
btn_opensave = ctk.CTkButton(master=frame, text="Open Savefile", command=LoadSaveFile, width=100, font=font_standard)
btn_opensave.grid(column=0, row=1, pady=12, padx=10)

savefile_path = ctk.StringVar(value="progress.sav")
entry_savefile = ctk.CTkEntry(master=frame, textvariable=savefile_path, state='disabled', width=400, font=font_standard)
entry_savefile.grid(columnspan=2, column=1, row=1, pady=12)


# Rupees
label_rupees = ctk.CTkLabel(master=frame, text="Rupees", font=font_label)
label_rupees.grid(row=3, pady=12, padx=10)

rupees = ctk.IntVar(value=0)
slider_rupees = ctk.CTkSlider(master=frame, from_=0, to=999_999, variable=rupees)
slider_rupees.grid(column=1, row=3, pady=12)

entry_rupees = ctk.CTkEntry(master=frame, textvariable=rupees, font=font_standard)
entry_rupees.grid(column=2, row=3, pady=12)


# Hearts
label_hearts = ctk.CTkLabel(master=frame, text="Hearts", font=font_label)
label_hearts.grid(row=4, pady=12, padx=10)

hearts = ctk.IntVar(value=1)
slider_hearts = ctk.CTkSlider(master=frame, from_=1, to=40, variable=hearts)
slider_hearts.grid(column=1, row=4, pady=12)

entry_hearts = ctk.CTkEntry(master=frame, textvariable=hearts, font=font_standard)
entry_hearts.grid(column=2, row=4, pady=12)


# Stamina
label_stamina = ctk.CTkLabel(master=frame, text="Stamina", font=font_label)
label_stamina.grid(row=5, pady=12, padx=10)

stamina = ctk.IntVar(value=1000)
slider_stamina = ctk.CTkSlider(master=frame, from_=1, to=10000, variable=stamina)
slider_stamina.grid(column=1, row=5, pady=12)

entry_stamina = ctk.CTkEntry(master=frame, textvariable=stamina, font=font_standard)
entry_stamina.grid(column=2, row=5, pady=12)


# Patch
btn_patchsave = ctk.CTkButton(master=frame, text="Patch Savefile", command=PatchSave, width=100, font=font_standard)
btn_patchsave.grid(column=1, row=6, pady=12, padx=10)

root.mainloop()
