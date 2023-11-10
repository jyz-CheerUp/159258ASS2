

var page_index = ["page-1", "page-2", "page-3", "page-4", "page-5", "page-6", "page-7", "page-8"];
var totalPage = page_index.length;

function page_option(pagename) {
	var tar_index = page_index.indexOf(pagename);
	page_index.slice(tar_index, 1);
	for (var j = 0; j < page_index.length; j++) {
		var close_div = document.getElementsByClassName(page_index[j]);
		for (var i = 0; i < close_div.length; i++) {
			close_div[i].style.display = "none";
		};
	}

	var opendiv = document.getElementsByClassName(pagename);
	for (var i = 0; i < opendiv.length; i++) {
		opendiv[i].style.display = "block";
	};
}

window.onload = function () {
	page_option("page-1"); // Display the first page
	document.getElementById('totalPage').value = totalPage; // Set the total number of pages
};


function first_click() {
	page_option("page-1");
	document.getElementById('currentPage').value = 1;
}

function last_click() {
	var total_page = document.getElementById('totalPage').value;
	page_option(page_index[page_index.length - 1]);
	document.getElementById('currentPage').value = total_page;
}


function prev_click() {
	var cur_page = document.getElementById('currentPage').value;
	if (cur_page > 1) {
		document.getElementById('currentPage').value = parseInt(cur_page) - 1;
		var pagename = page_index[parseInt(cur_page) - 2];
		page_option(pagename);
	}
}


function next_click() {
	var cur_page = document.getElementById('currentPage').value;
	var total_page = document.getElementById('totalPage').value;
	if (cur_page < total_page) {
		document.getElementById('currentPage').value = parseInt(cur_page) + 1;
		var pagename = page_index[parseInt(cur_page)];
		page_option(pagename);
	}
}


function choose_page() {
	var cur_page = document.getElementById('currentPage').value;
	var pagename = page_index[parseInt(cur_page) - 1];
	page_option(pagename);
}


// Gets the elements of the large image on the left
let b = document.querySelector(".b")
// Gets all the elements of the small image on the right
let d = document.getElementsByClassName("d")

let time
let index = 0

// Set a reset function
let a = function () {
    for (let i = 0; i < d.length; i++) {
        d[i].className = "d"
    }
}
// Set a select function
let aa = function () {
 // Prefix the reset function
    a()
    d[index].className = "d dd"
}
// Set the time function for starting the carousel
function ts() {
    time = setInterval(function () {
        aa()
        index++
        b.style.backgroundImage = "url('/Content/pic2/" + [index] + ".jpg')"
        if (index == 8) {
            index = 0
        }
    }, 1500);
}
for (let i = 0; i < d.length; i++) {
// Triggered when the mouse moves over the current small picture
    d[i].onmousemove = function () {
         // When the mouse moves to the current small picture, the big picture on the right becomes the current small picture
        b.style.backgroundImage = "url('/Content/pic2/" + [i + 1] + ".jpg')"
        a()
        clearInterval(time)
        index = i + 1
        ts()
    }
}
// Execute a carousel
ts()



