import matplotlib.pyplot as plt

# Example data
x1 = [1, 2, 3, 4, 5]
y1 = [40, 30, 55, 65, 90]

x2 = [1, 2, 3, 4, 5]
y2 = [50, 40, 65, 85, 100]

# Create the plot for the first line
plt.plot(x1, y1, label='Average Checkpoint Time')

# Create the plot for the second line
plt.plot(x2, y2, label='Average Playtime')

# Add title and labels
plt.title('Average Checkpoint Time and Playtime')
plt.xlabel('Level number')
plt.ylabel('Time (in second)')

# Add a legend
plt.legend()

# Show the plot
plt.show()