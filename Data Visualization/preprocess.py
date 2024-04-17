# Open the input file in read mode and the output file in write mode
with open('metric1.txt', 'r') as infile, open('output.txt', 'w') as outfile:
    # Read the file line by line
    for line in infile:
        # If the line does not start with "Platform", write it to the output file
        if not line.lstrip().startswith('Platform'):
            outfile.write(line)

# Open the input file in read mode and the output file in write mode
with open('metric1.txt', 'r') as infile, open('output.txt', 'w') as outfile:
    # Read the file line by line
    for line in infile:
        # Replace commas with periods and write the line to the output file
        outfile.write(line.replace(',', '.'))