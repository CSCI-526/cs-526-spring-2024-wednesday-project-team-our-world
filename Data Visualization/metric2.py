import matplotlib.pyplot as plt
from collections import Counter

# Read the file
with open('metric2.txt', 'r') as file:
    input_string = file.read()

# Parse the input string into a list
data = input_string.strip().split('\n')

# Count the occurrences of each level
counts = Counter(data)

# Create a bar chart for the data
plt.bar(counts.keys(), counts.values())
plt.xlabel('Levels')
plt.ylabel('Number of deaths')
plt.title('Times of players deaded')
plt.show()