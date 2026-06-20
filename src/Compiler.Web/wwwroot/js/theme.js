window.compilerTheme = {
    getTheme: function () {
        const saved = localStorage.getItem('compiler-theme');
        if (saved === 'dark' || saved === 'light') {
            document.documentElement.setAttribute('data-theme', saved);
            return saved;
        }

        const prefersDark = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
        const theme = prefersDark ? 'dark' : 'light';
        document.documentElement.setAttribute('data-theme', theme);
        return theme;
    },

    setTheme: function (theme) {
        const value = theme === 'dark' ? 'dark' : 'light';
        document.documentElement.setAttribute('data-theme', value);
        localStorage.setItem('compiler-theme', value);
        return value;
    },

    toggleTheme: function () {
        const current = this.getTheme();
        const next = current === 'dark' ? 'light' : 'dark';
        return this.setTheme(next);
    }
};