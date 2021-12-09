
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WorkoutModel {

    public WorkoutModel() {
    }

    private int id;

    private DateTime dateTimeStart;

    private DateTime dateTimeEnd;

    private int length;

    private EWorkoutStatus workoutStatus;

    private String instructor;

    private String customer;

    private Boolean isRemoved;

    public int Id { get => id; set => id = value; }
    public DateTime DateTimeStart { get => dateTimeStart; set => dateTimeStart = value; }
    public DateTime DateTimeEnd { get => dateTimeEnd; set => dateTimeEnd = value; }
    public int Length { get => length; set => length = value; }
    public EWorkoutStatus WorkoutStatus { get => workoutStatus; set => workoutStatus = value; }
    public string Instructor { get => instructor; set => instructor = value; }
    public string Customer { get => customer; set => customer = value; }
    public bool IsRemoved { get => isRemoved; set => isRemoved = value; }

    public WorkoutModel(DateTime dateTimeStart, DateTime dateTimeEnd, int length, EWorkoutStatus workoutStatus, string instructor, string customer, bool isRemoved)
    {
        DateTimeStart = dateTimeStart;
        DateTimeEnd = dateTimeEnd;
        Length = length;
        WorkoutStatus = workoutStatus;
        Instructor = instructor;
        Customer = customer;
        IsRemoved = isRemoved;
    }

}