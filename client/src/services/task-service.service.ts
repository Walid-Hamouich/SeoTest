import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Task from '../models/Task';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private httpClient: HttpClient, private router: Router) { }

  add(task: Task) {
    this.httpClient.post('http://localhost:5139/TaskItems/', task).subscribe({
      next: () => {
        this.router.navigate(['']);
      }
    });
  }

  getAll(callback: (tasks: Task[]) => void) {
    this.httpClient.get('http://localhost:5139/TaskItems/').subscribe({
      next: (obj: any) => {
        callback(obj);
      }
    });
  }
}
