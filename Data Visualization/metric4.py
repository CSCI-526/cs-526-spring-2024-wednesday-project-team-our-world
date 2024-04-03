import matplotlib.pyplot as plt
from collections import defaultdict, Counter

# Read the file
with open('metric4.txt', 'r') as file:
    input_string = file.read()

# Parse the input string into a dictionary of counters for each level
data = defaultdict(Counter)
for line in input_string.strip().split('\n'):
    level, value = line.split(': ')
    data[level][value] += 1

# Create a stacked bar chart for the data
for i, (level, counts) in enumerate(data.items()):
    plt.bar(i, counts['True'], color='blue')
    plt.bar(i, counts['False'], bottom=counts['True'], color='red')

plt.xticks(range(len(data)), data.keys())
plt.xlabel('Levels')
plt.ylabel('Counts')
plt.title('Players reaching checkpoints vs not reaching checkpoints (level-wise )') 
plt.legend(['Reach checkpoint', 'Did not reach checkpoint'])
plt.show()