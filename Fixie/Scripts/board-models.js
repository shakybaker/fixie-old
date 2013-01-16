var Card = function (id, name, description, complexity, priority, hasBugs) {
    var self = this;
    self.id = id;
    self.name = name;
    self.hasBugs = hasBugs;
    self.description = description;
    self.complexity = complexity;
    self.priority = priority;
    self.openCard = function () {
        fixie.showModal();
        $("#card-target").html("<h1>The card id = " + self.id + "</h1>");
    };
    self.cardId = ko.computed(function () {
        return "card-" + self.id;
    }, self);
    self.cardClass = ko.computed(function () {
        return "card-priority " + self.priority.toLowerCase();
    }, self);
};

var Column = function (id, sequence, name, cards) {
    var self = this;
    self.id = id;
    self.sequence = sequence;
    self.name = name;
    self.cards = ko.observableArray(cards);
    self.columnId = ko.computed(function () {
        return "lane-" + self.id;
    }, self);
    self.cardCount = ko.computed(function () {
        return self.cards().length + " CARDS";
    }, self);
    self.cardCountClass = ko.computed(function () {
        var countClass = "count";
        if (self.cards().length > 3) countClass += " warn";
        if (self.cards().length < 1) countClass += " none";
        return countClass;
    }, self);
};

var BoardViewModel = function (columns, availableCards) {
    var self = this;
    self.columns = ko.observableArray(columns);
    self.availableCards = ko.observableArray(availableCards);
    self.availableCards.id = "Available Cards";
    self.lastAction = ko.observable();
    self.lastError = ko.observable();
    self.maximumCards = 4;

    self.isColumnFull = function (parent) {
        return parent().length < self.maximumCards;
    };
    
    self.addColumn = function (element) {
        self.columns.push(element);
    };
    
    self.addCardToColumn = function (columnId, card) {
        $.each(self.columns(), function (idx, elem) {
            if (elem.id === columnId) {
                elem.cards.push(card);
                return false; //break out of the $.each loop
            }
        });
    };
    
    self.addCardAtIndex = function (columnId, card, i) {
        $.each(self.columns(), function (idx, elem) {
            if (elem.id === columnId) {
                elem.cards.splice(i, 0, card);
                return false; //break out of the $.each loop
            }
        });
    };
    
    self.replaceAllCardsInColumn = function (columnId, cards) {
        $.each(self.columns(), function (idx, elem) {
            elem.cards.removeAll();
            $.each(cards, function (idx2, card) {
                elem.cards.push(card);
            });
            elem.cards = cards;
            return false;
        });
    };

    self.deleteCard = function (cardId) {
        $.each(self.columns(), function (idx, elem) {
            elem.cards.remove(function (card) {
                return card.id === cardId;
            });
        });
        //board.countCards();
    };

    self.updateLastAction = function (arg) {
        //var arr = $(ui.item).attr('id').split('-');
        //var card = arr[1];
        //var lane = $(ui.item).parent().parent().attr('id');
        //var laneName = $('#' + lane).find('h2.lane-heading').html();
        //var index = $(ui.item).parent().children('li.card').index(ui.item);

        var laneId = $('#card-' + arg.item.id).parent().parent().attr('id');
        var laneName = $('#' + laneId).find('h2.lane-heading').html();//TODO: do this via the model
        var cardId = arg.item.id;
        var index = 1;

        var msg = "<span class='user-highlight'>Mark Baker</span> " + " moved card <strong>#" + cardId + "</strong> to <strong>" + laneName + "</strong>";
        hub.server.movedCard(cardId, laneId, index, msg);

        //self.lastAction("Moved " + arg.item.name() + " from " + arg.sourceParent.id + " (card " + (arg.sourceIndex + 1) + ") to " + arg.targetParent.id + " (card " + (arg.targetIndex + 1) + ")");
    };

};
