import os
import subprocess

def clear_screen():
    if os.name == "nt":
        subprocess.run(["cmd", "/c", "cls"], check=False)
    else:
        subprocess.run(["clear"], check=False)

def pause():
    input("\nPress any key to continue...")

def required_input(prompt: str) -> str:
    while True:
        value = input(f"{prompt}: ").strip()

        if value:
            return value

        input ("This field is required.Try again.\n")