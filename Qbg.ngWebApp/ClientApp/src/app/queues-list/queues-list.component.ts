import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-queues-list',
  templateUrl: './queues-list.component.html'
})
export class QueuesListComponent {
  public queueGet: QueueGet[]

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<QueueGet[]>(baseUrl + 'api/queue')        
      .subscribe(result => {        
      console.log(result);
      this.queueGet = result;
    },
      error => {
        console.error(error)
      });
  }
}

interface QueueGet {
  id: number;
  timeStamp: string;
  queue: QueueEntry[];
}

interface QueueEntry {
  username: string;
  timeStamp: string;
}
