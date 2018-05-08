import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { QueueService } from '../queue.service';
import { QueueGet } from '../QueueGet';


@Component({
  selector: 'app-queue-enqueue',
  templateUrl: './queue-enqueue.component.html',
  styleUrls: ['./queue-enqueue.component.css']
})
export class QueueEnqueueComponent implements OnInit {
  @Input() queueId: number;
  @Input() queueGet: QueueGet;
  @Input() current: string;
  @Output() enqueueSuccess = new EventEmitter<string>();

  constructor(private queueService: QueueService) { }

  ngOnInit() {
  }

  add(username: string) {
    this.queueService.enqueue(this.queueId, username)
      .subscribe(result => {
        console.log('successfully enqueued ' + username);
        this.enqueueSuccess.emit(username);
      },
        error => {
          console.error(error);
        });
  }
}
