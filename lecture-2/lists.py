
#names = ["Hans", "Tommy", "Joakim", "Emil", "Jeanette", "Gunilla", "Rebecca"]
#print(names)            # ['Hans', 'Tommy', 'Joakim', 'Emil', 'Jeanette', 'Gunilla', 'Rebecca']
#print(type(names))      # <class 'list'>
#print(len(names))       # 7
#print(names[4])         # Jeanette
#print(names[7])         # IndexError: list index out of range

#names = ["Hans", "Tommy", "Joakim", "Emil", "Jeanette", "Gunilla", "Rebecca"]
#names.append("Alicja")  # lägg till i slutet av listan
#print(names)            # ['Hans', 'Tommy', 'Joakim', 'Emil', 'Jeanette', 'Gunilla', 'Rebecca', 'Alicja']

#names = ["Hans", "Tommy", "Joakim", "Emil", "Jeanette", "Gunilla", "Rebecca"]
#names.pop()             # tar bort sista värdet i listan
#print(names)            # ['Hans', 'Tommy', 'Joakim', 'Emil', 'Jeanette', 'Gunilla']

#names = ["Hans", "Tommy", "Joakim", "Emil", "Jeanette", "Gunilla", "Rebecca"]
#names.pop(0)             # tar bort ett värde på en specifik position i listan 
#print(names)             # ['Tommy', 'Joakim', 'Emil', 'Jeanette', 'Gunilla', 'Rebecca']

#names = ["Hans", "Tommy", "Joakim", "Emil", "Jeanette", "Gunilla", "Rebecca"]
#names.clear()             # tar bort alla värden i listan
#print(names)              # []

#names = ["Hans", "Tommy", "Joakim", "Emil", "Jeanette", "Gunilla", "Rebecca"]
#names.insert(3, "Anton")    # lägg till ett värde på en specifik position
#print(names)                # ['Hans', 'Tommy', 'Joakim', 'Anton', 'Emil', 'Jeanette', 'Gunilla', 'Rebecca']


names = ["Hans", "Tommy", "Emil"]

for employee in names:
    print(employee)

