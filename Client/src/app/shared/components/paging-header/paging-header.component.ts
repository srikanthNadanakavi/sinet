import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.css'],
})
export class PagingHeaderComponent implements OnInit {
  @Input() pageIndex;
  @Input() pageSize;
  @Input() totalCount;

  constructor() {}

  ngOnInit(): void {}
}
