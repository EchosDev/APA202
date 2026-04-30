let card = document.createElement("div");
card.className = "card";
card.style.width = "300px";

let img = document.createElement("img");
img.setAttribute("src", "https://picsum.photos/300");
img.className = "card-img-top";

let cardBody = document.createElement("div");
cardBody.className = "card-body";

let cardTitle = document.createElement("h5");
cardTitle.className = "card-title";
cardTitle.textContent = "DETACHED HOUSE • 5Y OLD";

let cardPrice = document.createElement("p");
cardPrice.className = "card-text";
cardPrice.textContent = "$1,000,000";

let cardAddInfo = document.createElement("p");
cardAddInfo.className = "card-text";
cardAddInfo.textContent = "3 bedrooms, 2 bathrooms";

let cardRealtor = document.createElement("div");

let realtorImg = document.createElement("img");
realtorImg.setAttribute("src", "https://picsum.photos/50");
realtorImg.style.width = "30px";
realtorImg.style.borderRadius = "50%";

let realtorName = document.createElement("span");
realtorName.textContent = " Tiffany Heffner";

cardRealtor.appendChild(realtorImg);
cardRealtor.appendChild(realtorName);

cardBody.appendChild(cardTitle);
cardBody.appendChild(cardPrice);
cardBody.appendChild(cardAddInfo);
cardBody.appendChild(cardRealtor);

card.appendChild(img);
card.appendChild(cardBody);

document.body.appendChild(card);

card.style.border = "1px solid #ddd";
card.style.borderRadius = "10px";
card.style.fontFamily = "Arial";
cardBody.style.padding = "10px";
img.style.width = "100%";
img.style.borderRadius = "10px 10px 0 0";

cardRealtor.style.display = "flex";
cardRealtor.style.alignItems = "center";
cardRealtor.style.gap = "5px";
cardRealtor.style.marginTop = "10px";