var Site = {
    showDataSetStatistics: function (id)
    {
        if (id == '' || id == undefined) {
            alert("Failed");
            return;
        }

        var statisticsPanel = $("#statisticsPanel");

        $.ajax({
            url: "/Home/ShowStatistics",
            method: "POST",
            data: { dataSetId: id }
        })
            .done(function (response)
            {
                if (response.Success == true) {
                    statisticsPanel.removeClass("invisible");
                    $('#TotalUsersCount').text(response.TotalUsersCount);
                    $('#AverageFriendCountForUser').text(response.AverageFriendCountForUser);
                    $('#DatasetName').text(response.DataSetName);
                }
                else
                {
                    statisticsPanel.addClass("invisible");
                    alert('Failed');
                }
        })
        .fail(function () {
            alert("Error");
        });

    }
}