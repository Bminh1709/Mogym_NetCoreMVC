function showTab(tabName) {
    // Remove all active tabs
    const tabs = document.querySelectorAll('.tab');
    tabs.forEach(tab => {
        tab.classList.remove('active');
    });
    // Remove all active menu items
    const navTab = document.querySelectorAll('.sidebar-menu');
    navTab.forEach(tab => {
        tab.classList.remove('active');
    });

    // Add active tab
    const activeTab = document.getElementById(tabName);
    activeTab.classList.add('active');

    const activeNavTab = document.querySelector('.' + tabName);
    activeNavTab.classList.add('active');
}