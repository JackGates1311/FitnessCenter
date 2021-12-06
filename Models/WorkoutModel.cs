
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WorkoutModel {

    public WorkoutModel() {
    }

    private int id;

    private DateTime date;

    private DateTime time;

    private int length;

    private EWorkoutStatus workoutStatus;

    private String instructor;

    private String customer;

    private Boolean isRemoved;

    public int Id { get => id; set => id = value; }
    public DateTime Date { get => date; set => date = value; }
    public DateTime Time { get => time; set => time = value; }
    public int Length { get => length; set => length = value; }
    public EWorkoutStatus WorkoutStatus { get => workoutStatus; set => workoutStatus = value; }
    public string Instructor { get => instructor; set => instructor = value; }
    public string Customer { get => customer; set => customer = value; }
    public bool IsRemoved { get => isRemoved; set => isRemoved = value; }

}