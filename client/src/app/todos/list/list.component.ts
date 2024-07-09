import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../../services/task-service.service';
import Task from '../../../models/Task';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit {
  tasks: Task[] = [];

  constructor(private tasksService: TaskService) { }

  ngOnInit(): void {
    this.tasksService.getAll(tasks => {
      this.tasks = tasks;
    })
  }
}
