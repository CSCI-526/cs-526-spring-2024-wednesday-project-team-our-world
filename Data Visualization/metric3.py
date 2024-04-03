import matplotlib.pyplot as plt

# Input string
input_string = """
Ground: 2
3: 3
1: 2
5: 1
"""

# Parse the input string into a dictionary
data = {}
for line in input_string.strip().split('\n'):
    key, value = line.split(':')
    data[key] = int(value)

# Create the bar chart
plt.bar(data.keys(), data.values())
plt.xlabel('Keys')
plt.ylabel('Values')
plt.title('Bar Chart')
plt.show()