function TestViewModel() {
    this.questionsNext = [];
    this.questionsPrevious = [];
    this.currentQuestion = ko.observable();
    var that = this;
    $.getJSON("json/C_SharpTest.js", function (json) {
        that.questionsNext = json;

        console.log(that.questionsNext.length);
    });

    this.moveNext = function () {
        this.questionsPrevious.push(this.currentQuestion());
        this.currentQuestion(this.questionsNext.pop());
        console.log(this.currentQuestion());
        alert("FIRED");
    }

    this.movePrevious = function () {
        questionsNext.push(this.currentQuestion());
        this.currentQuestion(questionsPrevious.pop());
    }

}

ko.applyBindings(new TestViewModel());