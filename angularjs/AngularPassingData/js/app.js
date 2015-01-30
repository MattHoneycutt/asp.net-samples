(function() {
	window.app = angular.module('sampleApp', []);

	window.app.controller('NgInitSampleController', [NgInitSampleController]);
	function NgInitSampleController() {
		var vm = this;
		vm.people = [];

		vm.init = init;

		function init(people) {
			vm.people = people;
		}
	}

	window.app.controller('LocalValueProviderController', ['peopleData', LocalValueProviderController]);
	function LocalValueProviderController(peopleData) {
		var vm = this;
		vm.people = peopleData;
	}

	window.app.controller('GlobalValueProviderController', ['model', GlobalValueProviderController]);
	function GlobalValueProviderController(model) {
		var vm = this;
		vm.people = model;
	}
})();