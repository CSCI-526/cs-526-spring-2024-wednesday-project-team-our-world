# Input data
# Read the file
with open('output.txt', 'r') as file:
    data_string = file.read()

# Initialize variables
data = {}
current_level = None

# Parse the data
for line in data_string.split('\n'):
    line = line.strip()
    if line.startswith('"Level'):
        current_level = line.strip('"').strip(':')
        if current_level not in data and current_level not in ['Level 5', 'Level 6']:
            data[current_level] = {}
    elif line and ':' in line and current_level not in ['Level 5', 'Level 6']:
        key, value = line.split(':')
        key = key.strip()
        value = value.strip()
        if value and not key.startswith('Platform'):  # Check that the value is not an empty string and key does not start with 'Platform'
            value = float(value)
            if key in data[current_level]:
                data[current_level][key] += value
            else:
                data[current_level][key] = value

# Print the sums
for level, values in data.items():
    print(f'{level}:')
    for key, sum_value in values.items():
        print(f'  {key}: {sum_value}')

import matplotlib.pyplot as plt

# # Assuming data is a dictionary where the keys are the levels and the values are another dictionary with the keys and values to plot
# for level, values in data.items():
#     keys = list(values.keys())
#     values = list(values.values())
    
#     plt.figure(figsize=(10, 5))  # Create a new figure for each level
#     plt.bar(keys, values)  # Create a bar plot
#     plt.title(f"Time stay on stationary platforms for {level}")  # Set the title of the plot to the current level
#     plt.xlabel('Platform')  # Set the x-axis label
#     plt.ylabel('Seconds')  # Set the y-axis label
#     plt.show()  # Display the plot

# Initialize a dictionary to store the total sum for each level
total_sums = {}

# Calculate the sums and total sums
for level, values in data.items():
    total_sum = 0
    for key, sum_value in values.items():
        total_sum += sum_value
    total_sums[level] = total_sum

# Plot the total sums
levels = list(total_sums.keys())
sums = list(total_sums.values())

plt.figure(figsize=(10, 5))  # Create a new figure
plt.bar(levels, sums)  # Create a bar plot
plt.title("Total time stay on stationary platforms for each level")  # Set the title of the plot
plt.xlabel('Level')  # Set the x-axis label
plt.ylabel('Total Seconds')  # Set the y-axis label
plt.show()  # Display the plot