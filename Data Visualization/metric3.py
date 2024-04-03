import matplotlib.pyplot as plt

# Read the file
with open('metric3.txt', 'r') as file:
    input_string = file.read()

# Parse the input string into a dictionary of dictionaries
data = {}
current_level = None
for line in input_string.strip().split('\n'):
    if line.startswith('Level'):
        current_level = line
        data[current_level] = {}
    else:
        key, value = line.split(':')
        data[current_level][key] = float(value)

# Create a bar chart for each level
for level, level_data in data.items():
    plt.figure()  # Create a new figure for each level
    plt.bar(level_data.keys(), level_data.values())
    plt.xlabel('Platforms #')
    plt.ylabel('Values')
    plt.title(level)
plt.show()