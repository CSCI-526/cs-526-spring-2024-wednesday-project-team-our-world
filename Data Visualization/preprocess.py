    # Open the file in read mode and read its contents
with open('metric3.txt', 'r') as file:
    content = file.read()

# Replace all double quotes with nothing
content = content.replace('"', '')

# Open the file in write mode and write the modified content
with open('metric3.txt', 'w') as file:
    file.write(content)

# Open the file in read mode and read its contents
with open('metric3.txt', 'r') as file:
    lines = file.readlines()

# Filter out the empty lines
lines = [line for line in lines if line.strip() != '']

# Open the file in write mode and write the modified content
with open('metric3.txt', 'w') as file:
    file.writelines(lines)