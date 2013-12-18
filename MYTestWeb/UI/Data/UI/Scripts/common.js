String.prototype.trim = function () {
    var ret = "";
    var endTrimPos = 0;
    var startTrim = false;

    for (var i = this.length - 1; i >= 0; i--) {
        if (this[i] == " ") { continue; }
        endTrimPos = i;
        break;
    }

    for (var i = 0; i <= endTrimPos; i++) {
        if (this[i] == " " && !startTrim) { continue; }
        startTrim = true;
        ret += this[i];
    }

    return ret;
};