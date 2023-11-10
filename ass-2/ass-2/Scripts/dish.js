
document.addEventListener('DOMContentLoaded', function () {
    let listItems = document.querySelectorAll('.list');
    let contentBoxes = document.querySelectorAll('.contentbox');

    listItems.forEach(function (listItem) {
        listItem.addEventListener('click', function () {
          // Remove the 'active' class for all list items
            listItems.forEach(function (item) {
                item.classList.remove('active');
            });
            // Add the currently clicked list item to the 'active' class
            this.classList.add('active');

            let filterValue = this.getAttribute('data-filter');

            // Walk through the content box
            contentBoxes.forEach(function (box) {
                let contentFilter = box.getAttribute('data-content');

              // If the selected filter value is 'ALL' or matches the data-content of the content box, the content box is displayed, otherwise it is hidden
                if (filterValue === 'ALL' || filterValue === contentFilter) {
                    box.style.display = 'block';
                } else {
                    box.style.display = 'none';
                }
            });
        });
    });
});
