using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Computer Operator";
        job1._company = "Skylimit Educational Consult";
        job1._startYear = 2015;
        job1._endYear = 2017;

        Job job2 = new Job();
        job2._jobTitle = "Office Assistant";
        job2._company = "Matrix-dot Computer";
        job2._startYear = 2017;
        job2._endYear = 2018;

        Job job3 = new Job();
        job3._jobTitle = "Office Clerk";
        job3._company = "Federal Medical Center, Abeokuta";
        job3._startYear = 2021;
        job3._endYear = 2022;

        Resume myResume = new Resume();
        myResume._name = "Adam Adebesin";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.Display();
    }
}