import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../services/api.service';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-proyectos-list',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive, NgFor],
  templateUrl: './proyectos-list.component.html',
  styleUrl: './proyectos-list.component.scss'
})
export class ProyectosListComponent implements OnInit {
  projects: any[] = [];
  constructor(private api: ApiService) { }
  ngOnInit(): void {
    this.api.get('proyecto/GetUserProyectos').subscribe(res => this.projects = res);
  }

  deleteProject(id: number) {
    this.api.delete('projects', id).subscribe(() => {
      this.projects = this.projects.filter(p => p.id !== id);
    });
  }
}
