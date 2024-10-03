﻿// See https://aka.ms/new-console-template for more information

using ChainOfResponsibilities;

var mechanic = new Mechanic();
var detailer = new Detailer();
var wheels = new WheelSpecialist();
var qa = new QualityControl();

qa.SetNextServiceHandler(detailer);
wheels.SetNextServiceHandler(qa);
mechanic.SetNextServiceHandler(wheels);

Console.WriteLine("Car 1 is dirty");
mechanic.Service(new Car { Requirements = ServiceRequirements.Dirty });
Console.WriteLine();
Console.WriteLine("Car 2 requires full service");
mechanic.Service(new Car { Requirements = ServiceRequirements.Dirty |
                                          ServiceRequirements.EngineTune |
                                          ServiceRequirements.TestDrive |
                                          ServiceRequirements.WheelAlignment });