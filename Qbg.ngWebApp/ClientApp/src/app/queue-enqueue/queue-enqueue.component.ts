import { Component, OnInit, Input } from '@angular/core';

import { QueueService } from '../queue.service';


@Component({
  selector: 'app-queue-enqueue',
  templateUrl: './queue-enqueue.component.html',
  styleUrls: ['./queue-enqueue.component.css']
})
export class QueueEnqueueComponent implements OnInit {
  @Input()queueId: number;
  constructor(private queueService: QueueService) { }

  ngOnInit() {
  }

  add(username: string) {
    this.queueService.addQueue(this.queueId, username)
    .subscribe(result => 
      console.log(result),
    error => { 
      console.error(error); });
    }
}
