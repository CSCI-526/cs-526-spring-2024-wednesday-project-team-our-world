from collections import defaultdict

# Read the file
with open('metric2.txt', 'r') as file:
    input_string = file.read()


# Parse the input string into a dictionary of dictionaries for each level
data = defaultdict(lambda: defaultdict(int))
for line in input_string.strip().split('\n'):
    level, value = line.split(': ')
    if value.startswith('Platform') or value.startswith('Red'):
        data[level]['Explode'] += 1
    else:
        data[level]['Stationary'] += 1

# Print the counts
for level, counts in data.items():
    print(f"{level}: {counts}")

import matplotlib.pyplot as plt

# Create a stacked bar chart for the data
for i, (level, counts) in enumerate(data.items()):
    plt.bar(i, counts['Explode'], color='blue')
    plt.bar(i, counts['Stationary'], bottom=counts['Explode'], color='red')

plt.xticks(range(len(data)), data.keys())
plt.xlabel('Levels')
plt.ylabel('Counts')
plt.title('Explode vs Stationary Counts for Each Level')
plt.legend(['Explode', 'Stationary'])
plt.show()