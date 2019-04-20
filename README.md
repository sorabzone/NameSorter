# NameSorter
NameSorter Coding Challenge

# Requirement

Build a name sorter. Given a set of names, order that set first by last name, then by any given names the person may have. 
A name must have at least 1 given name and may have up to 3 given names.

Example Usage
Given a a file called unsorted-names-list.txt containing the following list of names:

Janet Parsons
Vaughn Lewis
Adonis Julius Archer
Shelby Nathan Yoder
Marin Alvarez
London Lindsey
Beau Tristan Bentley
Leo Gardner
Hunter Uriah Mathew Clarke
Mikayla Lopez
Frankie Conner Ritter


Executing the program should result the sorted names to screen:

Marin Alvarez
Adonis Julius Archer
Beau Tristan Bentley
Hunter Uriah Mathew Clarke
Leo Gardner
Vaughn Lewis
London Lindsey
Mikayla Lopez
Janet Parsons
Frankie Conner Ritter
Shelby Nathan Yoder

and a file in the working directory called sorted-names-list.txt containing the sorted names.

# How to Run & Test
1. Clone repository
2. Application is created in .Net Core, you need to publish to generate a self contained EXE and then run using command prompt providing input file name.
3. From Visual Studio - add "unsorted-names-list.txt" as argument in "NameSorter" project properties.

outut file get generated at following path "NameSorter\NameSorter\bin\Debug\netcoreapp2.1\sorted-names-list.txt"

4. To run application from command prompt - Go to "NameSorter\NameSorter" and execute following command

# dotnet run unsorted-names-list.txt

outut file get generated at following path "NameSorter\NameSorter\sorted-names-list.txt" 

5. To Run Test - Go to "NameSorter\NameSorter.UnitTest" and execute following command

# dotnet test


# Assumptions & Limitations
1. Error logs are written in console window. NLog nuget package is used, which can be configured to generate file as well.
2. Input file is available at root
3. Output file is generated at "NameSorter\NameSorter\bin\Debug\netcoreapp2.1\sorted-names-list.txt" 
4. If a person has multiple first names, we can sort them in left to right direction or vice versa.
By default the application will sort first names from left to right using "ForwardSortStrategy" class injected in Program.cs.
For reverse sorting, change the Program.cs to inject "BackwardSortStrategy".
5. CI/CD pipeline is created and integrated with AppVeyor to build and run tests.