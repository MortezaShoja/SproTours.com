function MessageBox(Title, Message) {
    document.getElementById("pageModalMessageBoxTitle").innerHTML = Title;
    document.getElementById("pageModalMessageBoxMessage").innerHTML = Message;
    $("#pageModalMessageBox").modal('show');
};

// Start Validation --------------------------------------------------
function ChildValidation() {
    var tmpchildflag = 'false'
    var ErMsg = ''
    var currentdate = new Date().format('dd/MMM/yyyy');

    if (document.getElementById("start").value < currentdate) {
        document.getElementById("start").style.borderColor = "red";
        ErMsg = 'تاریخ ورورد نمی تواند روزهای گذشته باشد'
    } else {
        document.getElementById("start").style.borderColor = "";
    }
    var tmpStartDate = document.getElementById("start").value.split("/");
    var LastMonth = new Date(tmpStartDate);
    LastMonth.setMonth(LastMonth.getMonth() + 1);

    var tmpEndDate = document.getElementById("end").value.split("/");

    if (Date.parse(tmpEndDate) > Date.parse(LastMonth)) {
        document.getElementById("end").style.borderColor = "red";
        if (ErMsg !== '') {
            ErMsg += '<br />' + 'تاریخ خروج نمی تواند بیشتر از یک ماه باشد'
        } else {
            ErMsg = 'تاریخ خروج نمی تواند بیشتر از یک ماه باشد'
        }
    } else {
        document.getElementById("end").style.borderColor = "";
    }


    //Start Child Validation ----------------------------------------------------
    var tmpchildno = document.getElementById("<%= ddlChild.ClientID %>").value

    try {
        if (document.getElementById("<%= ddlChild1.ClientID %>").value == "" && tmpchildno >= 1) {
            document.getElementById("<%= ddlChild1.ClientID %>").style.borderColor = "red";
            tmpchildflag = "true";
        } else {
            document.getElementById("<%= ddlChild1.ClientID %>").style.borderColor = "";
        }
    }
    catch (e) {
    }
    //---------------------
    try {
        if (document.getElementById("<%= ddlChild2.ClientID %>").value == "" && tmpchildno >= 2) {
            document.getElementById("<%= ddlChild2.ClientID %>").style.borderColor = "red";
            tmpchildflag = "true";
        } else {
            document.getElementById("<%= ddlChild2.ClientID %>").style.borderColor = "";
        }
    }
    catch (e) {
    }
    //---------------------
    try {
        if (document.getElementById("<%= ddlChild3.ClientID %>").value == "" && tmpchildno >= 3) {
            document.getElementById("<%= ddlChild3.ClientID %>").style.borderColor = "red";
            tmpchildflag = "true";
        } else {
            document.getElementById("<%= ddlChild3.ClientID %>").style.borderColor = "";
        }
    }
    catch (e) {
    }
    //---------------------
    try {
        if (document.getElementById("<%= ddlChild4.ClientID %>").value == "" && tmpchildno >= 4) {
            document.getElementById("<%= ddlChild4.ClientID %>").style.borderColor = "red";
            tmpchildflag = "true";
        } else {
            document.getElementById("<%= ddlChild4.ClientID %>").style.borderColor = "";
        }
    }
    catch (e) {
    }
    //---------------------
    try {
        if (document.getElementById("<%= ddlChild5.ClientID %>").value == "" && tmpchildno >= 5) {
            document.getElementById("<%= ddlChild5.ClientID %>").style.borderColor = "red";
            tmpchildflag = "true";
        } else {
            document.getElementById("<%= ddlChild5.ClientID %>").style.borderColor = "";
        }
    }
    catch (e) {
    }
    //---------------------
    try {
        if (document.getElementById("<%= ddlChild6.ClientID %>").value == "" && tmpchildno >= 6) {
            document.getElementById("<%= ddlChild6.ClientID %>").style.borderColor = "red";
            tmpchildflag = "true";
        } else {
            document.getElementById("<%= ddlChild6.ClientID %>").style.borderColor = "";
        }
    }
    catch (e) {
    }
    //---------------------
    try {
        if (document.getElementById("<%= ddlChild7.ClientID %>").value == "" && tmpchildno == 7) {
            document.getElementById("<%= ddlChild7.ClientID %>").style.borderColor = "red";
            tmpchildflag = "true";
        } else {
            document.getElementById("<%= ddlChild7.ClientID %>").style.borderColor = "";
        }
    }
    catch (e) {
    }

    //End Child Validation ----------------------------------------------------

    if (tmpchildflag == "true" | ErMsg !== '') {
        if (ErMsg !== '') {
            if (tmpchildflag == "true") {
                ErMsg += '<br />' + 'لطفاً سن تمامی کودکان را وارد کنید' + '<br />' + 'با تشکر'
            }
        } else {
            ErMsg = 'لطفاً سن تمامی کودکان را وارد کنید' + '<br />' + 'با تشکر'
        };

        MessageBox('خطا', ErMsg);
    } else {
        document.getElementById("<%= btnNewSearch.ClientID %>").click();
    }
}