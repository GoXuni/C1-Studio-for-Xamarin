using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using DashboardModel;
using C1.CollectionView;

namespace DashboardDemo.ViewModels
{
    public class TasksViewModel : INotifyPropertyChanged
    {
        DataService _service;
        FilterTaskType _taskType;

        public TasksViewModel()
        {
            _service = DataService.GetService();
            GroupName = String.Empty;
            _taskType = FilterTaskType.All;
        }

        public C1CollectionView<CampainTaskItem> Tasks
        {
            get
            {
                if (_service != null && _service.CampaignTaskCollction != null)
                    return _service.CampaignTaskCollction;
                else
                    return null;
            }
        }

        public String GroupName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async Task FilterAllTasksAsync()
        {
            _taskType = FilterTaskType.All;
            await FilterTasksAsync(_taskType);
        }

        public async Task FilterInProgressTasksAsync()
        {
            _taskType = FilterTaskType.InProgress;
            await FilterTasksAsync(_taskType);
        }

        public async Task FilterCompletedTasksAsync()
        {
            _taskType = FilterTaskType.Completed;
            await FilterTasksAsync(_taskType);
        }

        public async Task FilterDeferredTasksAsync()
        {
            _taskType = FilterTaskType.Deferred;
            await FilterTasksAsync(_taskType);
        }

        public async Task FilterUrgentTasksAsync()
        {
            _taskType = FilterTaskType.Urgent;
            await FilterTasksAsync(_taskType);
        }

        public async Task FilterMonthDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2017, 7, 1), new DateTime(2017, 8, 1));
            await FilterTasksAsync(_taskType);
        }

        public async Task Filter3MonthsDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2017, 5, 1), new DateTime(2017, 8, 1));
            await FilterTasksAsync(_taskType);
        }

        public async Task Filter6MonthsDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2017, 2, 1), new DateTime(2017, 8, 1));
            await FilterTasksAsync(_taskType);
        }

        public async Task FilterYearDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2016, 8, 1), new DateTime(2017, 8, 1));
            await FilterTasksAsync(_taskType);
        }

        public async Task Filter2YearsDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2016, 1, 1), new DateTime(2017, 8, 1));
            await FilterTasksAsync(_taskType);
        }

        public async Task GroupTasks(String name)
        {
            if (!String.IsNullOrEmpty(name) && GroupName != name)
            {
                GroupName = name;
                await _service.CampaignTaskCollction.GroupAsync(GroupName);
            }
        }

        private async Task FilterTasksAsync(FilterTaskType type)
        {
            await _service.UpdataCampainTaskTypeAsync((CampainTaskType)type);
            if (!String.IsNullOrEmpty(GroupName))
                await _service.CampaignTaskCollction.GroupAsync(GroupName);
        }

        private async Task FilterByDateRangeAsync(DateTime start, DateTime end)
        {
            if (_service.DateRange != null && _service.DateRange.Start == start && _service.DateRange.End == end)
                return;

            _service.DateRange = new DateRange() { Start = start, End = end };
            await _service.UpdataDataByDateRangeAsync();
            OnPropertyChanged("Tasks");
        }
    }

    public enum FilterTaskType
    {
        All,
        InProgress,
        Completed,
        Deferred,
        Urgent
    }
}
