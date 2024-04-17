import matplotlib.pyplot as plt
from collections import defaultdict, Counter
import numpy as np

# Read the file
with open('metric3.txt', 'r') as file:
    input_string = file.read()

# Parse the input string into a dictionary for each level
data = defaultdict(lambda: [0, 0])
for line in input_string.strip().split('\n'):
    level, values = line.split(':')
    value1, value2 = map(int, values.split(','))
    data[level.strip()][0] += value1
    data[level.strip()][1] += value2

# Prepare data for plotting
levels = list(data.keys())
sum1_values = [value[0] for value in data.values()]
sum2_values = [value[1] for value in data.values()]

# Create a figure and a set of subplots
fig, ax = plt.subplots()

# Plot the data
bar_width = 0.35
index = np.arange(len(levels))
rects1 = ax.bar(index, sum1_values, bar_width, label='number of Q rotations ')
rects2 = ax.bar(index + bar_width, sum2_values, bar_width, label='number of E rotations')

# Add some text for labels, title and custom x-axis tick labels, etc.
ax.set_xlabel('Levels')
ax.set_ylabel('Values')
ax.set_title('Number of Q and E Rotations for Each Level')
ax.set_xticks(index + bar_width / 2)
ax.set_xticklabels(levels)
ax.legend()

# Show the plot
plt.show()