import {Component} from '@angular/core';
import {Router} from "@angular/router";
import {SectionService} from "../../../services/section.service";

@Component({
  selector: 'app-section-list',
  templateUrl: './section-list.component.html',
  styleUrls: ['./section-list.component.scss']
})
export class SectionListComponent {
  displayedColumns = ['sectionId', 'sectionName', 'actions'];
  sectionList = this.sectionService.all();

  constructor(protected router: Router,
              private sectionService: SectionService) {
  }

  add() {
    this.router.navigate(['section', 'add']);
  }

  view(id: number) {
    this.router.navigate(['section', 'view', id]);
  }

  edit(id: number) {
    this.router.navigate(['section', 'edit', id]);
  }

  delete(id: number) {
    this.sectionService.delete(id).subscribe({
      next: (result) => {
        this.sectionList = this.sectionService.all();
      }
    });
  }
}
