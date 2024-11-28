import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeDTO } from 'src/app/models/employee-dto';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit{
  employees: EmployeeDTO[] = [];
  currentPage: number = 2;
  pageSize: number = 5;
  totalPages: any;
  //pageSizes: number[] = [5, 10, 20];
  
  constructor(private employeeService: EmployeeService){}

  ngOnInit(){
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.employeeService.getEmployees(this.currentPage, this.pageSize).subscribe((response) => {
      if (response && response.items) {
        this.employees = response.items;
        this.totalPages = response.totalPages;
        this.currentPage = response.currentPage; // Sync currentPage with the response
      }
    });
  }
  // loadEmployees(): void {
  //   this.employeeService.getEmployees(this.currentPage, this.pageSize).subscribe((response) => {
  //     if (Array.isArray(response)) {
  //       this.employees = response; // Bind plain array
  //       this.totalPages = 1; // Hardcode or calculate as needed (e.g., based on total count if available)
  //       this.currentPage = 1; // Assume page 1 since backend isn't paginated
  //     } else {
  //       console.error("Unexpected response structure:", response);
  //     }
  //   }, error => {
  //     console.error("Failed to load employees:", error);
  //   });
  // }

  onPageSizeChange(){
    this.currentPage = 1; // Reset to first page when page size changes
    this.loadEmployees();
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.loadEmployees();
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadEmployees();
    }
  }

  deleteEmployee(id: number){
    if(confirm('Are you sure you want to delete this employee?')) {
      this.employeeService.deleteEmployee(id).subscribe(() => {
        this.loadEmployees();
      });
    }
  }
}

