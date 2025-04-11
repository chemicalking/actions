import tkinter as tk
from tkinter import messagebox

def main():
    root = tk.Tk()
    root.withdraw()
    messagebox.showinfo("測試", "這是由GitHub Actions建構的執行檔！")
    root.destroy()

if __name__ == "__main__":
    main()
