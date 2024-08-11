/* 
This C# console application is designed to:
- Use arrays to store student names and assignment scores.
- Use a foreach statement to iterate through the student names as an outer program loop.
- Use an if statement within the outer loop to identify the current student name and access that student's assignment scores.
- Use a foreach statement within the outer loop to iterate though the assignment scores array and sum the values.
- Use an algorithm within the outer loop to calculate the average exam score for each student.
- Use an if-elseif-else construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
- Integrate extra credit scores when calculating the student's final score and letter grade as follows:
    - detects extra credit assignments based on the number of elements in the student's scores array.
    - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
- use the following report format to report student grades: 

Student         Exam Score      Overall Grade   Extra Credit

Sophia          92.2            95.88   A       92 (3.68 pts)

*/

int examAssignments = 5;

string[] studentNames = { "Sophia", "Andrew", "Emma", "Logan" };

int[][] allScores = new int[][]
{
    new int[] { 90, 86, 87, 98, 100, 94, 90 },
    new int[] { 92, 89, 81, 96, 90, 89 },
    new int[] { 90, 85, 87, 98, 68, 89, 89, 89 },
    new int[] { 90, 95, 87, 88, 96, 96 }
};

string[] letterGrades = { "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "F" };
decimal[] gradeThresholds = { 97, 93, 90, 87, 83, 80, 77, 73, 70, 67, 63, 60, 0 };

Console.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall Grade\tLetter Grade\tExtra Credit");

for (int i = 0; i < studentNames.Length; i++)
{
    string currentStudent = studentNames[i];
    int[] studentScores = allScores[i];

    int sumExamScores = 0, sumExtraCreditScores = 0;
    int gradedAssignments = Math.Min(examAssignments, studentScores.Length);
    int extraCredits = Math.Max(0, studentScores.Length - examAssignments);

    // Sum exam and extra credit scores
    for (int j = 0; j < gradedAssignments; j++)
    {
        sumExamScores += studentScores[j];
    }
    
    for (int j = examAssignments; j < studentScores.Length; j++)
    {
        sumExtraCreditScores += studentScores[j];
    }

    decimal examAverage = (decimal)sumExamScores / gradedAssignments;
    decimal extraCreditAverage = extraCredits > 0 ? (decimal)sumExtraCreditScores / extraCredits : 0;
    decimal finalGrade = examAverage + ((decimal)sumExtraCreditScores / 10 / examAssignments);

    // Determine letter grade
    string currentStudentLetterGrade = letterGrades[Array.FindIndex(gradeThresholds, grade => finalGrade >= grade)];

    Console.WriteLine($"{currentStudent}\t\t{examAverage:F2}\t\t{finalGrade:F2}\t\t{currentStudentLetterGrade}\t\t{sumExtraCreditScores} ({(sumExtraCreditScores / 10m / examAssignments):F2} pts)");
}

Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();