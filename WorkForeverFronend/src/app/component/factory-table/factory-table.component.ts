import { Component } from '@angular/core';
import {GetFactoryDto} from "../../Dto/GetFactoryDto";
import {MatTableDataSource} from "@angular/material/table";
import {FactoryService} from "../../service/factory.service";

@Component({
  selector: 'app-factory-table',
  templateUrl: './factory-table.component.html',
  styleUrls: ['./factory-table.component.scss']
})
export class FactoryTableComponent {
  factories: MatTableDataSource<GetFactoryDto> = new MatTableDataSource<GetFactoryDto>();
  constructor(private  factoryService: FactoryService
  ) {
    this.GenerateFactoryTable();
  }
  displayedColumns: string[] = ['Id', 'Level', 'Salary', 'Work'];
  GenerateFactoryTable(){
    console.log("GenerateFactoryTable");
    this.factoryService.getAllFactories().subscribe(response => {
      console.log (response);
      if (response.success)
      {
        this.factories.data = response.data;

        console.log(this.factories);
      }
    });

  }

  work(factoryId:number) {
    console.log("work");
    this.factoryService.work(factoryId).subscribe(response => {
      console.log (response);
      if (response.success)
        console.log(response.data);
    });
  }
}
