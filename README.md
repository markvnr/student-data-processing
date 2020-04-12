# student-data-processing
a console application in C# for collecting and calculating student's final result for a single subject

## Release v0.1
the first release allow to add students from input and calculate their final result based on average and median

## Release v0.2
the second release adds the functionallity to add students from file

## Release v0.3
the third release adds exceptions and try/catch blocks
the exceptions are used in the student class and the try/catch blocks are used wherever a new student is created

## Release v0.4
the fourth release adds functionallity to generate 3 files with different amount of random studnet records in each 
the data is grouped by the final points. studnets who got final points less than 5 are failed and those who got 5 and higher passed
the elepsed time for each file is given below:</br>
file 1 executed 6804 ms </br>
file 2 executed 14744 ms </br>
file 3 executed 94882 ms </br>
file 4 executed 916370 ms </br>

## Release  v0.5
the fifth release adds to the previous release and compares the time required for performing the operations of splitting the data and saving it in a file.</br>
there different implemetations using list, linked list and queue.
the elapsed time for each file using linked list and queue is given below:</br>
</br>
LinkedList:</br>
file 1 executed 7362 ms </br>
file 2 executed 17117 ms </br>
file 3 executed 111729 ms </br>
file 4 executed 1190549 ms </br>
</br>
Queue: </br>
file 1 executed 7241 </br>
file 2 executed 17898 </br>
file 3 executed 122477 </br>
file 4 executed 1045261 </br>
</br>
the conclusion is that linked list works faster for this case.

## Release v1.0
the final release tries to investigate the effect of different container type on the performance of splittng the data
