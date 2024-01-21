function onLoadIndexPage() {
    const svgContainer = document.querySelector('#svgContainer svg');
    const colors = ['#ff0000', '#00ff00', '#0000ff', '#ff00ff', '#ffffff', '#000000'];
    let xPos = 0;
    while (xPos < svgContainer.getAttribute('width')) {
        let newRect = document.createElementNS('http://www.w3.org/2000/svg', 'rect');
        newRect.setAttribute('x', xPos);
        newRect.setAttribute('y', 0);
        newRect.setAttribute('width', 40);
        newRect.setAttribute('height', 100);
        newRect.setAttribute('fill', colors[Math.floor(Math.random() * colors.length)]);
        svgContainer.appendChild(newRect);
        xPos += 40;
    }
};
