define(['Models/InstructorModel'], function (InstructorModel) {
	function InstructorViewModel() {
		
		var self = this;

		this.Load = function (id) {
			var instructorModelObj = new instructorModel();
			instructorModelObj.Load(id, function (result) {
				var viewModel = {
					first: ko.observable(result.FirstName),
					last: ko.observable(result.LastName),
					id: result.Id,
					update: function() {
						self.UpdateInstructor(this);
					}
				}
				ko.applyBindings(viewModel, document.getElementById("divInstructorEdit"));
			});
		};

		this.UpdateInstructor = function (viewModel) {
			var instructorModelObj = new instructorModel();
			var instructorData = {
				Id: viewModel.id,
				FirstName: viweModel.first(),
				LastName: viewModel.last()
			};

			instructorModelObj.Update(instructorData, function (message) {
				$('#divMessage').html(message);
			});
		};
	}
	return InstructorViewModel;
});