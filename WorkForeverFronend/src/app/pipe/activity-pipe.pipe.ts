import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'activityPipe'
})
export class ActivityPipePipe implements PipeTransform {

  transform(value: Date, maxInactiveHours= 12): string {
    console.log("value = ", value);
    if (value == null) {
      return "inactive";
    }
    let now = new Date();
    let diff = now.getTime() - new Date(value).getTime();
    let diffDays = Math.floor(diff / (1000 * 3600));
    if (diffDays > maxInactiveHours) {
      return "inactive";
    } else {
      return "active";
    }
  }

}
