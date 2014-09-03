// AdminViewModel depends on the Models/AdminModel to process requests (Load, Update)
define(['Models/AdminModel'], function (adminModel) {
    function AdminViewModel() {
        var self = this;
        var initialBind = true;

        this.Load = function (id) {
            var adminModelObj = new adminModel();

            // Because the Load() is a async call (asynchronous), we'll need to use
            // the callback approach to handle the data after data is loaded.
            adminModelObj.Load(id, function (result) {

                var viewModel = {
                    first: ko.observable(result.FirstName),
                    last : ko.observable(result.LastName),
                    id: result.Id,
                    update: function() {
                        self.UpdateAdmin(this);
                    }
                }

                ko.applyBindings(viewModel , document.getElementById("divAdminEdit"));
            });
        };

        this.UpdateAdmin = function (viewModel) {
            var adminModelObj = new adminModel();

            // convert the viewModel to same structure as PLAdmin model (presentation layer model)
            var adminData = {
                Id: viewModel.id,
                FirstName: viewModel.first(),
                LastName: viewModel.last()
            };

            adminModelObj.Update(adminData, function (message) {
                $('#divMessage').html(message);
            });

        };
        
        this.GetAllSchedules = function () {
            var adminModelObj = new adminModel();
            var scheduleListViewModel = ko.observableArray();
            adminModelObj.GetSchedules(function (scheduleList) {
                scheduleListViewModel.removeAll();
                for (var i = 0; i < scheduleList.length; i++) {
                    scheduleListViewModel.push({
                        year: scheduleList[i].Year,
                        quarter: scheduleList[i].Quarter,
                        session: scheduleList[i].Session,
                        course_title: scheduleList[i].CourseTitle,
                        course_description: scheduleList[i].CourseDescription,
                        course_id: scheduleList[i].CourseId,
                        schedule_id: scheduleList[i].ScheduleId
                    });
                }

                if (initialBind) {
                    ko.applyBindings({ viewModel: scheduleListViewModel }, document.getElementById("divScheduleListContent"));
                    initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
                }
            });
        };

        this.GetYears = function () {
            var adminModelObj = new adminModel();
            var yearListViewModel = ko.observableArray();
            adminModelObj.GetYears(function (yearList) {
                yearListViewModel.removeAll();
                yearListViewModel.push({year: "All Years"});
                for (var i = 0; i < yearList.length; i++) {
                    yearListViewModel.push({
                        year: yearList[i]
                    });
                }

                ko.applyBindings({ viewModel1: yearListViewModel }, document.getElementById("yearListContent"));
            });
        }

        this.GetQuarters = function () {
            var adminModelObj = new adminModel();
            var quarterListViewModel = ko.observableArray();
            adminModelObj.GetQuarters(function (quarterList) {
                quarterListViewModel.removeAll();
                quarterListViewModel.push({ quarter: "All Quarters" });
                for (var i = 0; i < quarterList.length; i++) {
                    quarterListViewModel.push({
                        quarter: quarterList[i]
                    });
                }

                ko.applyBindings({ viewModel2: quarterListViewModel }, document.getElementById("quarterListContent"));
            });
        }
    }
    return AdminViewModel;
}
);