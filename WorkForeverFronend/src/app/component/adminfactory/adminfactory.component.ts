import { Component } from '@angular/core';
import {WorkService} from "../../service/work.service";
import {GetWorkRecordDto} from "../../Dto/GetWorkRecordDto";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-adminfactory',
  templateUrl: './adminfactory.component.html',
  styleUrls: ['./adminfactory.component.scss']
})
export class AdminfactoryComponent {

    workRecords: GetWorkRecordDto[] = [];
    constructor(private workService: WorkService,
                private route: ActivatedRoute) {
      this.route.params.subscribe( params => {
        console.log ("params = ", params);
        let factoryId:number = params['id'];
        console.log ("factoryId = ", factoryId);
        this.workService.getWorkHistoryForFactory(factoryId).subscribe(response => {
          if (response.success) {
            this.workRecords = response.data;
            console.log("this.workRecords = ", this.workRecords)
          }
        });
      } );
    }

}
