# import matplotlib.pyplot as plt

# # Input string
# input_string = """
# Level 4:
# 2: 4.588427
# 3: 22.81782
# 1: 3.001075
# 5: 8.795606
# 6: 9.035648
# 7: 12.21458
# 8: 28.83128
# 9: 29.69398
# 4: 19.22486
# 11: 31.32875
# 10: 30.57106
# Level 4:
# 2: 4.588427
# 3: 22.81782
# 1: 3.001075
# 5: 8.795606
# 6: 9.035648
# 7: 12.21458
# 8: 28.83128
# 9: 29.69398
# 4: 19.22486
# 11: 33.74878
# 10: 30.57106
# Level 2:
# 1: 2.1878
# 2: 0
# 3: 3.1555
# 4: 11.92841
# 5: 0
# 6: 0
# 7: 13.84682
# 8: 0
# 9: 0
# 10: 0
# 11: 0
# 12: 0
# 13: 0
# 14: 0
# 15: 0
# 16: 0
# 17: 0
# 18: 0
# Level 2:
# 1: 2.1878
# 2: 0
# 3: 3.1555
# 4: 11.92841
# 5: 0
# 6: 0
# 7: 13.84682
# 8: 0
# 9: 0
# 10: 0
# 11: 0
# 12: 0
# 13: 0
# 14: 0
# 15: 0
# 16: 0
# 17: 0
# 18: 0
# Level 4:
# 1: 4.518335
# Level 4:
# 2: 1.481068
# 3: 1.568371
# 1: 6.416886
# 10: 9.907966
# """

# # Parse the input string into a dictionary of dictionaries
# data = {}
# current_level = None
# for line in input_string.strip().split('\n'):
#     if line.startswith('Level'):
#         current_level = line
#         data[current_level] = {}
#     else:
#         key, value = line.split(':')
#         data[current_level][key] = float(value)

# # Create a bar chart for each level
# for level, level_data in data.items():
#     plt.figure()  # Create a new figure for each level
#     plt.bar(level_data.keys(), level_data.values())
#     plt.xlabel('Keys')
#     plt.ylabel('Values')
#     plt.title('Bar Chart for ' + level)
# plt.show()

import matplotlib.pyplot as plt

# Read the file
with open('metric1.txt', 'r') as file:
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