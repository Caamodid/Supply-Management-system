module.exports = [
"[project]/src/layout/AppHeader.tsx [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react-jsx-dev-runtime.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$context$2f$SidebarContext$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/context/SidebarContext.tsx [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$image$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/image.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$client$2f$app$2d$dir$2f$link$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/client/app-dir/link.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
"use client";
;
;
;
;
;
const AppHeader = ()=>{
    const [isApplicationMenuOpen, setApplicationMenuOpen] = (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useState"])(false);
    const { isMobileOpen, toggleSidebar, toggleMobileSidebar } = (0, __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$context$2f$SidebarContext$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useSidebar"])();
    const inputRef = (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useRef"])(null);
    const handleToggle = ()=>{
        if (window.innerWidth >= 1024) {
            toggleSidebar();
        } else {
            toggleMobileSidebar();
        }
    };
    const toggleApplicationMenu = ()=>{
        setApplicationMenuOpen((prev)=>!prev);
    };
    (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useEffect"])(()=>{
        const handleKeyDown = (event)=>{
            if ((event.metaKey || event.ctrlKey) && event.key === "k") {
                event.preventDefault();
                inputRef.current?.focus();
            }
        };
        document.addEventListener("keydown", handleKeyDown);
        return ()=>document.removeEventListener("keydown", handleKeyDown);
    }, []);
    return /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("header", {
        className: "sticky top-0 w-full h-14 bg-[#0B1A2A] border-b border-gray-200 dark:bg-gray-900 dark:border-gray-800",
        children: [
            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                className: "flex items-center justify-between h-full px-3 lg:px-6",
                children: [
                    /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                        className: "flex items-center gap-2",
                        children: [
                            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("button", {
                                onClick: handleToggle,
                                className: "flex items-center justify-center w-9 h-9 rounded-lg border border-gray-200 text-gray-500 dark:border-gray-800 dark:text-gray-400",
                                "aria-label": "Toggle Sidebar",
                                children: isMobileOpen ? /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("svg", {
                                    width: "20",
                                    height: "20",
                                    viewBox: "0 0 24 24",
                                    fill: "currentColor",
                                    children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("path", {
                                        d: "M18.3 5.71L12 12l6.3 6.29-1.42 1.42L12 13.41l-6.29 6.3-1.42-1.42L10.59 12 4.29 5.71 5.71 4.29 12 10.59l6.29-6.3z"
                                    }, void 0, false, {
                                        fileName: "[project]/src/layout/AppHeader.tsx",
                                        lineNumber: 53,
                                        columnNumber: 17
                                    }, ("TURBOPACK compile-time value", void 0))
                                }, void 0, false, {
                                    fileName: "[project]/src/layout/AppHeader.tsx",
                                    lineNumber: 52,
                                    columnNumber: 15
                                }, ("TURBOPACK compile-time value", void 0)) : /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("svg", {
                                    width: "18",
                                    height: "12",
                                    viewBox: "0 0 18 12",
                                    fill: "currentColor",
                                    children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("path", {
                                        d: "M0 1h18v2H0V1zm0 4h12v2H0V5zm0 4h18v2H0V9z"
                                    }, void 0, false, {
                                        fileName: "[project]/src/layout/AppHeader.tsx",
                                        lineNumber: 57,
                                        columnNumber: 17
                                    }, ("TURBOPACK compile-time value", void 0))
                                }, void 0, false, {
                                    fileName: "[project]/src/layout/AppHeader.tsx",
                                    lineNumber: 56,
                                    columnNumber: 15
                                }, ("TURBOPACK compile-time value", void 0))
                            }, void 0, false, {
                                fileName: "[project]/src/layout/AppHeader.tsx",
                                lineNumber: 46,
                                columnNumber: 11
                            }, ("TURBOPACK compile-time value", void 0)),
                            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$client$2f$app$2d$dir$2f$link$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {
                                href: "/",
                                className: "lg:hidden",
                                children: [
                                    /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$image$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {
                                        src: "/images/logo/logo.svg",
                                        alt: "Logo",
                                        width: 130,
                                        height: 28,
                                        className: "dark:hidden"
                                    }, void 0, false, {
                                        fileName: "[project]/src/layout/AppHeader.tsx",
                                        lineNumber: 64,
                                        columnNumber: 13
                                    }, ("TURBOPACK compile-time value", void 0)),
                                    /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$image$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {
                                        src: "/images/logo/logo-dark.svg",
                                        alt: "Logo",
                                        width: 130,
                                        height: 28,
                                        className: "hidden dark:block"
                                    }, void 0, false, {
                                        fileName: "[project]/src/layout/AppHeader.tsx",
                                        lineNumber: 71,
                                        columnNumber: 13
                                    }, ("TURBOPACK compile-time value", void 0))
                                ]
                            }, void 0, true, {
                                fileName: "[project]/src/layout/AppHeader.tsx",
                                lineNumber: 63,
                                columnNumber: 11
                            }, ("TURBOPACK compile-time value", void 0)),
                            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                                className: "hidden lg:block",
                                children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                                    className: "relative",
                                    children: [
                                        /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("span", {
                                            className: "absolute left-3 top-1/2 -translate-y-1/2 text-gray-400",
                                            children: "🔍"
                                        }, void 0, false, {
                                            fileName: "[project]/src/layout/AppHeader.tsx",
                                            lineNumber: 83,
                                            columnNumber: 15
                                        }, ("TURBOPACK compile-time value", void 0)),
                                        /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("input", {
                                            ref: inputRef,
                                            type: "text",
                                            placeholder: "Search or type command...",
                                            className: "h-9 w-[420px] rounded-lg border border-gray-200 bg-transparent pl-10 pr-14 text-sm text-gray-800 placeholder:text-gray-400 focus:border-brand-300 focus:ring-2 focus:ring-brand-500/10 dark:border-gray-800 dark:bg-white/[0.03] dark:text-white/90 dark:placeholder:text-white/30"
                                        }, void 0, false, {
                                            fileName: "[project]/src/layout/AppHeader.tsx",
                                            lineNumber: 87,
                                            columnNumber: 15
                                        }, ("TURBOPACK compile-time value", void 0)),
                                        /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("span", {
                                            className: "absolute right-2 top-1/2 -translate-y-1/2 rounded border px-2 py-1 text-xs text-gray-500 dark:border-gray-700 dark:text-gray-400",
                                            children: "⌘ K"
                                        }, void 0, false, {
                                            fileName: "[project]/src/layout/AppHeader.tsx",
                                            lineNumber: 96,
                                            columnNumber: 15
                                        }, ("TURBOPACK compile-time value", void 0))
                                    ]
                                }, void 0, true, {
                                    fileName: "[project]/src/layout/AppHeader.tsx",
                                    lineNumber: 82,
                                    columnNumber: 13
                                }, ("TURBOPACK compile-time value", void 0))
                            }, void 0, false, {
                                fileName: "[project]/src/layout/AppHeader.tsx",
                                lineNumber: 81,
                                columnNumber: 11
                            }, ("TURBOPACK compile-time value", void 0))
                        ]
                    }, void 0, true, {
                        fileName: "[project]/src/layout/AppHeader.tsx",
                        lineNumber: 44,
                        columnNumber: 9
                    }, ("TURBOPACK compile-time value", void 0)),
                    /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                        className: "flex items-center gap-2",
                        children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("button", {
                            onClick: toggleApplicationMenu,
                            className: "lg:hidden flex items-center justify-center w-9 h-9 rounded-lg hover:bg-gray-100 dark:hover:bg-gray-800",
                            children: "⋮"
                        }, void 0, false, {
                            fileName: "[project]/src/layout/AppHeader.tsx",
                            lineNumber: 108,
                            columnNumber: 11
                        }, ("TURBOPACK compile-time value", void 0))
                    }, void 0, false, {
                        fileName: "[project]/src/layout/AppHeader.tsx",
                        lineNumber: 104,
                        columnNumber: 9
                    }, ("TURBOPACK compile-time value", void 0))
                ]
            }, void 0, true, {
                fileName: "[project]/src/layout/AppHeader.tsx",
                lineNumber: 42,
                columnNumber: 7
            }, ("TURBOPACK compile-time value", void 0)),
            isApplicationMenuOpen && /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                className: "flex items-center justify-end gap-3 px-4 py-2 border-t border-gray-200 dark:border-gray-800 lg:hidden"
            }, void 0, false, {
                fileName: "[project]/src/layout/AppHeader.tsx",
                lineNumber: 119,
                columnNumber: 9
            }, ("TURBOPACK compile-time value", void 0))
        ]
    }, void 0, true, {
        fileName: "[project]/src/layout/AppHeader.tsx",
        lineNumber: 41,
        columnNumber: 5
    }, ("TURBOPACK compile-time value", void 0));
};
const __TURBOPACK__default__export__ = AppHeader;
}),
"[externals]/next/dist/server/app-render/action-async-storage.external.js [external] (next/dist/server/app-render/action-async-storage.external.js, cjs)", ((__turbopack_context__, module, exports) => {

const mod = __turbopack_context__.x("next/dist/server/app-render/action-async-storage.external.js", () => require("next/dist/server/app-render/action-async-storage.external.js"));

module.exports = mod;
}),
"[externals]/next/dist/server/app-render/work-unit-async-storage.external.js [external] (next/dist/server/app-render/work-unit-async-storage.external.js, cjs)", ((__turbopack_context__, module, exports) => {

const mod = __turbopack_context__.x("next/dist/server/app-render/work-unit-async-storage.external.js", () => require("next/dist/server/app-render/work-unit-async-storage.external.js"));

module.exports = mod;
}),
"[externals]/next/dist/server/app-render/work-async-storage.external.js [external] (next/dist/server/app-render/work-async-storage.external.js, cjs)", ((__turbopack_context__, module, exports) => {

const mod = __turbopack_context__.x("next/dist/server/app-render/work-async-storage.external.js", () => require("next/dist/server/app-render/work-async-storage.external.js"));

module.exports = mod;
}),
"[project]/src/icons/plus.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgPlus = function SvgPlus(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 12,
        height: 12,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M5.25 3a.75.75 0 0 1 1.5 0v2.25H9a.75.75 0 0 1 0 1.5H6.75V9a.75.75 0 0 1-1.5 0V6.75H3a.75.75 0 0 1 0-1.5h2.25z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgPlus;
}),
"[project]/src/icons/close.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgClose = function SvgClose(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none",
        className: "close_svg__fill-current"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fillRule: "evenodd",
        d: "M6.043 16.542a1 1 0 1 0 1.414 1.414L12 13.414l4.542 4.542a1 1 0 0 0 1.414-1.414L13.413 12l4.542-4.542a1 1 0 0 0-1.414-1.414l-4.542 4.542-4.542-4.542A1 1 0 1 0 6.043 7.46L10.585 12z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgClose;
}),
"[project]/src/icons/box.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgBox = function SvgBox(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M9.777 3.242a.5.5 0 0 1 .447 0l5.147 2.574-5.035 2.517a.75.75 0 0 1-.67 0L4.63 5.816zM3.703 7.03v6.383a.5.5 0 0 0 .276.448l5.271 2.635V9.784a2 2 0 0 1-.256-.109zm7.047 9.467V9.784a2 2 0 0 0 .257-.109l5.291-2.646v6.383a.5.5 0 0 1-.276.448zm-1.335.987-.309.617a2 2 0 0 0 1.789 0l5.798-2.899a2 2 0 0 0 1.105-1.789V6.588A2 2 0 0 0 16.693 4.8l-5.798-2.898a2 2 0 0 0-1.789 0l.336.67-.336-.67-5.798 2.898a2 2 0 0 0-1.105 1.79v6.823a2 2 0 0 0 1.105 1.79L9.106 18.1z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgBox;
}),
"[project]/src/icons/check-circle.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgCheckCircle = function SvgCheckCircle(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M3.55 12a8.448 8.448 0 1 1 16.897 0 8.448 8.448 0 0 1-16.896 0M12 2.052c-5.494 0-9.948 4.454-9.948 9.948s4.454 9.948 9.948 9.948 9.948-4.454 9.948-9.948S17.493 2.052 12 2.052m3.514 8.581a.75.75 0 1 0-1.061-1.06l-3.264 3.263-1.642-1.642a.75.75 0 0 0-1.06 1.06l2.172 2.173a.75.75 0 0 0 1.06 0z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgCheckCircle;
}),
"[project]/src/icons/alert.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgAlert = function SvgAlert(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M13.95 3.875c-.866-1.5-3.031-1.5-3.897 0l-7.506 13c-.866 1.5.216 3.375 1.949 3.375h15.01c1.733 0 2.815-1.875 1.95-3.375zm-2.598.75a.75.75 0 0 1 1.299 0l7.505 13a.75.75 0 0 1-.65 1.125H4.497a.75.75 0 0 1-.65-1.125zm.65 3.936a.75.75 0 0 1 .75.75v4.22a.75.75 0 0 1-1.5 0V9.31a.75.75 0 0 1 .75-.75M11 16.08a1 1 0 1 1 1 1 1 1 0 0 1-1-1",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgAlert;
}),
"[project]/src/icons/info.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgInfo = function SvgInfo(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M3.5 12a8.5 8.5 0 1 1 17 0 8.5 8.5 0 0 1-17 0M12 2C6.477 2 2 6.477 2 12s4.477 10 10 10 10-4.477 10-10S17.523 2 12 2m-1 5.525a1 1 0 1 0 1.001-1h-.002a1 1 0 0 0-1 1m1 9.846a.75.75 0 0 1-.75-.75v-5.676a.75.75 0 0 1 1.5 0v5.676a.75.75 0 0 1-.75.75",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgInfo;
}),
"[project]/src/icons/info-hexa.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgInfoHexa = function SvgInfoHexa(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M8.125 4.54h7.749a.75.75 0 0 1 .65.374l3.874 6.711a.75.75 0 0 1 0 .75l-3.875 6.71a.75.75 0 0 1-.65.376H8.126a.75.75 0 0 1-.65-.375L3.6 12.375a.75.75 0 0 1 0-.75l3.875-6.71a.75.75 0 0 1 .65-.376m7.749-1.5h-7.75a2.25 2.25 0 0 0-1.948 1.124l-3.875 6.711a2.25 2.25 0 0 0 0 2.25l3.875 6.71a2.25 2.25 0 0 0 1.949 1.126h7.749a2.25 2.25 0 0 0 1.948-1.125l3.875-6.711a2.25 2.25 0 0 0 0-2.25l-3.875-6.71a2.25 2.25 0 0 0-1.948-1.126M12 7.81a.75.75 0 0 1 .75.75v4.22a.75.75 0 0 1-1.5 0V8.56a.75.75 0 0 1 .75-.75M11 15.33a1 1 0 1 1 1 1 1 1 0 0 1-1-1",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgInfoHexa;
}),
"[project]/src/icons/bolt.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgBolt = function SvgBolt(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 26,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        stroke: "currentColor",
        strokeLinecap: "round",
        strokeLinejoin: "round",
        strokeWidth: 1.5,
        d: "M12.814 4.75 4.785 16.035h6.4v7.215l8.03-11.285h-6.401z"
    })));
};
const __TURBOPACK__default__export__ = SvgBolt;
}),
"[project]/src/icons/arrow-up.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgArrowUp = function SvgArrowUp(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 13,
        height: 12,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M6.065 1.624a.75.75 0 0 1 .558-.25h.001c.192 0 .384.073.531.22l3 2.998a.75.75 0 1 1-1.06 1.06l-1.722-1.72v6.193a.75.75 0 0 1-1.5 0v-6.19L4.155 5.654a.75.75 0 0 1-1.06-1.061z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgArrowUp;
}),
"[project]/src/icons/arrow-down.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgArrowDown = function SvgArrowDown(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 12,
        height: 12,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M5.315 10.376c.137.153.336.25.558.25h.001a.75.75 0 0 0 .531-.22l3-2.998a.75.75 0 1 0-1.06-1.06l-1.722 1.72V1.875a.75.75 0 1 0-1.5 0v6.19L3.405 6.346a.75.75 0 0 0-1.06 1.061z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgArrowDown;
}),
"[project]/src/icons/folder.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgFolder = function SvgFolder(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 18,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        d: "m9.05 3.9-.6.45zm-6.8-1.65H6.5V.75H2.25zM1.5 15V3H0v12zm16.25.75H2.25v1.5h15.5zM18.5 6v9H20V6zm-.75-2.25h-7.5v1.5h7.5zm-8.1-.3L8.3 1.65l-1.2.9 1.35 1.8zm.6.3a.75.75 0 0 1-.6-.3l-1.2.9a2.25 2.25 0 0 0 1.8.9zM20 6a2.25 2.25 0 0 0-2.25-2.25v1.5a.75.75 0 0 1 .75.75zm-2.25 11.25A2.25 2.25 0 0 0 20 15h-1.5a.75.75 0 0 1-.75.75zM0 15a2.25 2.25 0 0 0 2.25 2.25v-1.5A.75.75 0 0 1 1.5 15zM6.5 2.25a.75.75 0 0 1 .6.3l1.2-.9a2.25 2.25 0 0 0-1.8-.9zM2.25.75A2.25 2.25 0 0 0 0 3h1.5a.75.75 0 0 1 .75-.75z"
    })));
};
const __TURBOPACK__default__export__ = SvgFolder;
}),
"[project]/src/icons/videos.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgVideos = function SvgVideos(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 25,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        stroke: "currentColor",
        strokeLinejoin: "round",
        strokeWidth: 1.5,
        d: "M6.708 5.931V18.07a1.5 1.5 0 0 0 2.285 1.278l9.884-6.069a1.5 1.5 0 0 0 0-2.556L8.993 4.653a1.5 1.5 0 0 0-2.285 1.278Z"
    })));
};
const __TURBOPACK__default__export__ = SvgVideos;
}),
"[project]/src/icons/audio.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgAudio = function SvgAudio(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 25,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M21.417 4a.75.75 0 0 0-.889-.737l-12 2.25a.75.75 0 0 0-.611.737v8.209A3.95 3.95 0 0 0 6.042 14c-.875 0-1.694.27-2.311.74-.618.47-1.064 1.174-1.064 2.01s.446 1.54 1.064 2.01c.617.47 1.436.74 2.31.74s1.694-.27 2.311-.74c.606-.46 1.047-1.146 1.064-1.96v-6.18l10.5-2.01v3.599a3.95 3.95 0 0 0-1.874-.459c-.875 0-1.694.27-2.311.74-.618.47-1.064 1.174-1.064 2.01s.446 1.54 1.064 2.01c.617.47 1.436.74 2.31.74s1.694-.27 2.311-.74c.606-.46 1.047-1.146 1.064-1.96V4m-1.5 10.5c0-.268-.141-.564-.474-.818-.333-.253-.826-.432-1.401-.432s-1.069.179-1.402.432c-.332.254-.473.55-.473.818s.14.564.473.818c.333.253.826.432 1.402.432.575 0 1.068-.179 1.401-.432.333-.254.474-.55.474-.818M7.443 15.932c.333.254.474.55.474.818s-.141.564-.474.818c-.333.253-.826.432-1.401.432s-1.069-.179-1.402-.432c-.332-.254-.473-.55-.473-.818s.14-.564.473-.818c.333-.253.826-.432 1.402-.432.575 0 1.068.179 1.401.432m12.474-8.85V4.904l-10.5 1.968v2.22z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgAudio;
}),
"[project]/src/icons/grid.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgGrid = function SvgGrid(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M5.5 3.25A2.25 2.25 0 0 0 3.25 5.5V9a2.25 2.25 0 0 0 2.25 2.25H9A2.25 2.25 0 0 0 11.25 9V5.5A2.25 2.25 0 0 0 9 3.25zM4.75 5.5a.75.75 0 0 1 .75-.75H9a.75.75 0 0 1 .75.75V9a.75.75 0 0 1-.75.75H5.5A.75.75 0 0 1 4.75 9zm.75 7.25A2.25 2.25 0 0 0 3.25 15v3.5a2.25 2.25 0 0 0 2.25 2.25H9a2.25 2.25 0 0 0 2.25-2.25V15A2.25 2.25 0 0 0 9 12.75zM4.75 15a.75.75 0 0 1 .75-.75H9a.75.75 0 0 1 .75.75v3.5a.75.75 0 0 1-.75.75H5.5a.75.75 0 0 1-.75-.75zm8-9.5A2.25 2.25 0 0 1 15 3.25h3.5a2.25 2.25 0 0 1 2.25 2.25V9a2.25 2.25 0 0 1-2.25 2.25H15A2.25 2.25 0 0 1 12.75 9zM15 4.75a.75.75 0 0 0-.75.75V9c0 .414.336.75.75.75h3.5a.75.75 0 0 0 .75-.75V5.5a.75.75 0 0 0-.75-.75zm0 8A2.25 2.25 0 0 0 12.75 15v3.5A2.25 2.25 0 0 0 15 20.75h3.5a2.25 2.25 0 0 0 2.25-2.25V15a2.25 2.25 0 0 0-2.25-2.25zM14.25 15a.75.75 0 0 1 .75-.75h3.5a.75.75 0 0 1 .75.75v3.5a.75.75 0 0 1-.75.75H15a.75.75 0 0 1-.75-.75z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgGrid;
}),
"[project]/src/icons/file.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgFile = function SvgFile(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 25,
        height: 24,
        fill: "none",
        className: "file_svg__fill-current"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M19.834 19.75a2.25 2.25 0 0 1-2.25 2.25h-10.5a2.25 2.25 0 0 1-2.25-2.25V9.621c0-.596.236-1.169.658-1.59L10.86 2.66A2.25 2.25 0 0 1 12.45 2h5.133a2.25 2.25 0 0 1 2.25 2.25zm-2.25.75a.75.75 0 0 0 .75-.75V4.25a.75.75 0 0 0-.75-.75h-5.002l.002 4a2.25 2.25 0 0 1-2.25 2.25h-4v10c0 .414.335.75.75.75zM7.393 8.25l3.69-3.691.001 2.941a.75.75 0 0 1-.75.75zm1.19 6.25a.75.75 0 0 1 .75-.75h6a.75.75 0 0 1 0 1.5h-6a.75.75 0 0 1-.75-.75m0 3a.75.75 0 0 1 .75-.75h3a.75.75 0 0 1 0 1.5h-3a.75.75 0 0 1-.75-.75",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgFile;
}),
"[project]/src/icons/download.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgDownload = function SvgDownload(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 25,
        height: 24,
        fill: "none",
        className: "download_svg__fill-current"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M12.669 16.75a.75.75 0 0 1-.548-.237l-4.61-4.607a.75.75 0 0 1 1.06-1.061l3.348 3.345V4a.75.75 0 0 1 1.5 0v10.185l3.343-3.34a.75.75 0 0 1 1.06 1.06l-4.575 4.573a.75.75 0 0 1-.578.272M5.417 16a.75.75 0 0 0-1.5 0v2.5a2.25 2.25 0 0 0 2.25 2.25h13a2.25 2.25 0 0 0 2.25-2.25V16a.75.75 0 0 0-1.5 0v2.5a.75.75 0 0 1-.75.75h-13a.75.75 0 0 1-.75-.75z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgDownload;
}),
"[project]/src/icons/arrow-right.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgArrowRight = function SvgArrowRight(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M17.418 9.999a.75.75 0 0 1-.22.531l-4.997 5a.75.75 0 1 1-1.06-1.06l3.72-3.723H3.332a.75.75 0 0 1 0-1.5h11.522L11.14 5.53a.75.75 0 0 1 1.061-1.06l4.958 4.96c.158.138.259.34.259.567z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgArrowRight;
}),
"[project]/src/icons/group.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgGroup = function SvgGroup(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M8.804 5.602a2.197 2.197 0 1 0 0 4.393 2.197 2.197 0 0 0 0-4.393M5.107 7.799a3.697 3.697 0 1 1 7.394 0 3.697 3.697 0 0 1-7.394 0m-.244 7.522c-.775.767-1.16 1.74-1.346 2.54a.37.37 0 0 0 .09.35c.095.103.26.188.469.188h9.349c.21 0 .374-.085.469-.188a.37.37 0 0 0 .09-.35c-.187-.8-.57-1.773-1.346-2.54-.756-.749-1.948-1.366-3.888-1.366s-3.131.617-3.887 1.366m-1.056-1.066c1.065-1.054 2.649-1.8 4.943-1.8 2.295 0 3.88.746 4.944 1.8 1.046 1.036 1.527 2.306 1.75 3.265.322 1.377-.837 2.379-2.02 2.379H4.077c-1.182 0-2.341-1.002-2.02-2.379.224-.96.705-2.23 1.751-3.265m11.497-2.76a3.68 3.68 0 0 1-2.222-.742c.292-.422.523-.889.681-1.389a2.197 2.197 0 1 0 0-3.132c-.158-.5-.389-.966-.681-1.388a3.697 3.697 0 1 1 2.222 6.652m4.62 8.404H16.39a3.14 3.14 0 0 0 .593-1.5h2.942c.21 0 .374-.085.469-.188a.37.37 0 0 0 .09-.35c-.187-.8-.571-1.773-1.346-2.54-.733-.726-1.877-1.329-3.715-1.364a7.4 7.4 0 0 0-1.431-1.42 9 9 0 0 1 1.258-.082c2.295 0 3.88.746 4.944 1.8 1.046 1.036 1.527 2.306 1.75 3.265.322 1.377-.837 2.379-2.02 2.379",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgGroup;
}),
"[project]/src/icons/box-line.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgBoxLine = function SvgBoxLine(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M11.665 3.756a.75.75 0 0 1 .67 0l6.446 3.223-6.445 3.222a.75.75 0 0 1-.671 0L5.22 6.979zM4.293 8.192v7.903c0 .284.16.543.415.67l6.542 3.272V11.65a2 2 0 0 1-.256-.108zm8.457 11.845 6.543-3.272a.75.75 0 0 0 .415-.67V8.192l-6.701 3.35q-.126.063-.257.11zm.257-17.622a2.25 2.25 0 0 0-2.013 0L4.037 5.893a2.25 2.25 0 0 0-1.244 2.013v8.189a2.25 2.25 0 0 0 1.244 2.012l6.957 3.479.336-.671-.336.67a2.25 2.25 0 0 0 2.013 0l6.957-3.478a2.25 2.25 0 0 0 1.244-2.012v-8.19a2.25 2.25 0 0 0-1.244-2.012z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgBoxLine;
}),
"[project]/src/icons/shooting-star.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgShootingStar = function SvgShootingStar(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M20.366 1.112a.75.75 0 0 1 1.06 1.06l-4.395 4.396a.75.75 0 0 1-1.06-1.06zM16.66 2.696a.75.75 0 0 0-1.06-1.06l-1.5 1.5a.75.75 0 1 0 1.06 1.06zm-4.825.759a.75.75 0 0 0-1.345 0L8.064 8.368l-5.422.788a.75.75 0 0 0-.415 1.28L6.15 14.26l-.926 5.4a.75.75 0 0 0 1.088.79l4.85-2.549 4.85 2.55a.75.75 0 0 0 1.088-.791l-.927-5.4 3.924-3.825a.75.75 0 0 0-.416-1.279l-5.422-.788zm-2.6 5.93 1.928-3.904 1.926 3.905a.75.75 0 0 0 .565.41l4.309.626-3.118 3.039a.75.75 0 0 0-.216.664l.736 4.29-3.853-2.025a.75.75 0 0 0-.698 0l-3.854 2.026.736-4.291a.75.75 0 0 0-.216-.664l-3.117-3.04 4.308-.625a.75.75 0 0 0 .565-.41m12.417-4.257a.75.75 0 0 1 0 1.06l-1.5 1.5a.75.75 0 1 1-1.06-1.06l1.5-1.5a.75.75 0 0 1 1.06 0",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgShootingStar;
}),
"[project]/src/icons/dollar-line.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgDollarLine = function SvgDollarLine(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 25,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M13.416 2.792a.75.75 0 0 0-1.5 0v1.607a4.05 4.05 0 0 0-.857 7.8l2.688 1.008a2.548 2.548 0 0 1-.894 4.934h-1.057a1.863 1.863 0 0 1-1.864-1.864.75.75 0 0 0-1.5 0 3.363 3.363 0 0 0 3.364 3.364h.12v1.567a.75.75 0 0 0 1.5 0v-1.606a4.049 4.049 0 0 0 .858-7.8l-2.688-1.008a2.548 2.548 0 0 1 .895-4.934h1.056c1.03 0 1.864.834 1.864 1.863a.75.75 0 0 0 1.5 0 3.363 3.363 0 0 0-3.364-3.363h-.12z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgDollarLine;
}),
"[project]/src/icons/trash.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgTrash = function SvgTrash(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M6.541 3.792a2.25 2.25 0 0 1 2.25-2.25h2.417a2.25 2.25 0 0 1 2.25 2.25v.25h3.208a.75.75 0 0 1 0 1.5h-.29v10.666a2.25 2.25 0 0 1-2.25 2.25h-8.25a2.25 2.25 0 0 1-2.25-2.25V5.541h-.292a.75.75 0 1 1 0-1.5H6.54zm8.334 9.454V5.541h-9.75v10.667c0 .414.336.75.75.75h8.25a.75.75 0 0 0 .75-.75zM8.041 4.041h3.917v-.25a.75.75 0 0 0-.75-.75H8.791a.75.75 0 0 0-.75.75zM8.334 8a.75.75 0 0 1 .75.75v5a.75.75 0 1 1-1.5 0v-5a.75.75 0 0 1 .75-.75m4.083.75a.75.75 0 0 0-1.5 0v5a.75.75 0 1 0 1.5 0z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgTrash;
}),
"[project]/src/icons/angle-up.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgAngleUp = function SvgAngleUp(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 8,
        height: 5,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        d: "M4.41.585a.5.5 0 0 0-.82 0L1.05 4.213A.5.5 0 0 0 1.46 5h5.08a.5.5 0 0 0 .41-.787z"
    })));
};
const __TURBOPACK__default__export__ = SvgAngleUp;
}),
"[project]/src/icons/angle-down.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgAngleDown = function SvgAngleDown(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 8,
        height: 5,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        d: "M4.41 4.415a.5.5 0 0 1-.82 0L1.05.787A.5.5 0 0 1 1.46 0h5.08a.5.5 0 0 1 .41.787z"
    })));
};
const __TURBOPACK__default__export__ = SvgAngleDown;
}),
"[project]/src/icons/pencil.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgPencil = function SvgPencil(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 21,
        height: 21,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M17.091 3.532a2.25 2.25 0 0 0-3.182 0l-8.302 8.302c-.308.308-.52.7-.61 1.126l-.735 3.485a.75.75 0 0 0 .888.889l3.485-.735a2.25 2.25 0 0 0 1.127-.611l8.301-8.302a2.25 2.25 0 0 0 0-3.182zm-2.121 1.06a.75.75 0 0 1 1.06 0l.973.973a.75.75 0 0 1 0 1.06l-.899.899-2.033-2.033zm-1.96 1.96-6.342 6.342a.75.75 0 0 0-.203.376l-.498 2.358 2.358-.497a.75.75 0 0 0 .376-.204l6.343-6.342z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgPencil;
}),
"[project]/src/icons/check-line.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgCheckLine = function SvgCheckLine(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 16,
        height: 16,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        stroke: "currentColor",
        strokeLinecap: "round",
        strokeLinejoin: "round",
        strokeWidth: 1.8,
        d: "m13.402 4.36-7.28 7.28-3.524-3.523"
    })));
};
const __TURBOPACK__default__export__ = SvgCheckLine;
}),
"[project]/src/icons/close-line.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgCloseLine = function SvgCloseLine(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 17,
        height: 16,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M4.054 4.78a.75.75 0 0 1 1.06-1.06l3.22 3.22 3.218-3.218a.75.75 0 1 1 1.06 1.06L9.396 8l3.218 3.218a.75.75 0 0 1-1.06 1.06L8.333 9.061l-3.22 3.22a.75.75 0 0 1-1.06-1.061L7.274 8z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgCloseLine;
}),
"[project]/src/icons/chevron-down.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgChevronDown = function SvgChevronDown(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        stroke: "currentColor",
        strokeLinecap: "round",
        strokeLinejoin: "round",
        strokeWidth: 1.5,
        d: "M4.792 7.396 10 12.604l5.208-5.208"
    })));
};
const __TURBOPACK__default__export__ = SvgChevronDown;
}),
"[project]/src/icons/chevron-up.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgChevronUp = function SvgChevronUp(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        stroke: "currentColor",
        strokeLinecap: "round",
        strokeLinejoin: "round",
        strokeWidth: 1.25,
        d: "M15.833 12.708 10.625 7.5l-5.208 5.208"
    })));
};
const __TURBOPACK__default__export__ = SvgChevronUp;
}),
"[project]/src/icons/paper-plane.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgPaperPlane = function SvgPaperPlane(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M4.985 2.444c-1.872-.873-3.832 1.026-3.02 2.924l1.856 4.337a.75.75 0 0 1 0 .59l-1.856 4.337c-.812 1.899 1.148 3.797 3.02 2.925l11.833-5.517c1.733-.808 1.733-3.271 0-4.079zm-1.64 2.334c-.271-.633.382-1.265 1.006-.975l11.834 5.518a.75.75 0 0 1 0 1.359L4.35 16.197c-.624.29-1.277-.342-1.006-.975L5.2 10.885a2 2 0 0 0 .054-.138h3.864a.75.75 0 0 0 0-1.5H5.252a2 2 0 0 0-.052-.132z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgPaperPlane;
}),
"[project]/src/icons/lock.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path, _path2;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgLock = function SvgLock(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "#667085",
        d: "M10.625 13.958a.625.625 0 0 0-1.25 0v1.25a.625.625 0 0 0 1.25 0z"
    })), _path2 || (_path2 = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M10 1.667a4.375 4.375 0 0 0-4.375 4.375v1.562H4.584c-1.036 0-1.875.84-1.875 1.875v6.979c0 1.035.839 1.875 1.874 1.875h10.834c1.035 0 1.875-.84 1.875-1.875V9.479c0-1.036-.84-1.875-1.875-1.875h-1.042V6.042A4.375 4.375 0 0 0 10 1.667m3.125 4.375v1.562h-6.25V6.042a3.125 3.125 0 0 1 6.25 0M4.584 8.854a.625.625 0 0 0-.625.625v6.979c0 .345.28.625.624.625h10.834c.345 0 .625-.28.625-.625V9.479a.625.625 0 0 0-.625-.625z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgLock;
}),
"[project]/src/icons/envelope.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgEnvelope = function SvgEnvelope(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M3.042 7.062v7.313a.5.5 0 0 0 .5.5h12.916a.5.5 0 0 0 .5-.5V7.062l-5.814 4.055a2 2 0 0 1-2.288 0zm13.916-1.87V5.2a.07.07 0 0 1-.03.055l-6.642 4.631a.5.5 0 0 1-.572 0L3.072 5.255a.071.071 0 0 1 .041-.13h13.774c.038 0 .07.03.071.068m1.5.022v9.161a2 2 0 0 1-2 2H3.542a2 2 0 0 1-2-2v-9.21a1.57 1.57 0 0 1 1.571-1.54h13.774c.868 0 1.571.703 1.571 1.571z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgEnvelope;
}),
"[project]/src/icons/user-line.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgUserLine = function SvgUserLine(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M8.025 6.178a2.303 2.303 0 1 1 4.607 0 2.303 2.303 0 0 1-4.607 0m2.304-3.803a3.803 3.803 0 1 0 0 7.607 3.803 3.803 0 0 0 0-7.607M8.923 11.03a5.714 5.714 0 0 0-5.714 5.714v.29a.75.75 0 0 0 1.5 0v-.29a4.214 4.214 0 0 1 4.214-4.214h2.813a4.214 4.214 0 0 1 4.214 4.214v.29a.75.75 0 1 0 1.5 0v-.29a5.714 5.714 0 0 0-5.714-5.714z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgUserLine;
}),
"[project]/src/icons/calender-line.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgCalenderLine = function SvgCalenderLine(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M8 2a.75.75 0 0 1 .75.75v1h6.5v-1a.75.75 0 0 1 1.5 0v1h1.75A2.25 2.25 0 0 1 20.75 6v13a2.25 2.25 0 0 1-2.25 2.25h-13A2.25 2.25 0 0 1 3.25 19V6A2.25 2.25 0 0 1 5.5 3.75h1.75v-1A.75.75 0 0 1 8 2m0 3.25H5.5a.75.75 0 0 0-.75.75v2.25h14.5V6a.75.75 0 0 0-.75-.75H8m11.25 4.5H4.75V19c0 .414.336.75.75.75h13a.75.75 0 0 0 .75-.75z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgCalenderLine;
}),
"[project]/src/icons/eye.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgEye = function SvgEye(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "currentColor"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fillRule: "evenodd",
        d: "M10 13.862a6.52 6.52 0 0 1-6.077-4.16 6.519 6.519 0 0 1 12.154 0A6.52 6.52 0 0 1 10 13.862m0-9.819a8.02 8.02 0 0 0-7.584 5.416.75.75 0 0 0 0 .487 8.019 8.019 0 0 0 15.169 0 .75.75 0 0 0 0-.487A8.02 8.02 0 0 0 10 4.043m-.008 3.801a1.858 1.858 0 1 0 0 3.716h.014a1.858 1.858 0 0 0 0-3.716z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgEye;
}),
"[project]/src/icons/eye-close.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgEyeClose = function SvgEyeClose(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "currentColor"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fillRule: "evenodd",
        d: "M4.638 3.577a.75.75 0 0 0-1.06 1.06l1.275 1.277a8.03 8.03 0 0 0-2.437 3.545.75.75 0 0 0 0 .487 8.02 8.02 0 0 0 11.083 4.614l1.864 1.863a.75.75 0 1 0 1.06-1.06zm7.723 9.844-1.914-1.913q-.212.052-.44.053h-.015a1.858 1.858 0 0 1-1.803-2.312l-2.27-2.27a6.53 6.53 0 0 0-1.996 2.723 6.52 6.52 0 0 0 8.438 3.72m3.716-3.719a6.5 6.5 0 0 1-1.257 2.03l1.061 1.06a8 8 0 0 0 1.704-2.846.75.75 0 0 0 0-.487A8.02 8.02 0 0 0 7.522 4.433l1.23 1.23q.607-.12 1.248-.12a6.52 6.52 0 0 1 6.077 4.16",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgEyeClose;
}),
"[project]/src/icons/time.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgTime = function SvgTime(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M3.042 10a6.958 6.958 0 1 1 13.916 0 6.958 6.958 0 0 1-13.916 0M10 1.542a8.458 8.458 0 1 0 0 16.916 8.458 8.458 0 0 0 0-16.916m0 9.208a.75.75 0 0 1-.75-.75V5.417a.75.75 0 0 1 1.5 0V9.25h2.583a.75.75 0 0 1 0 1.5z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgTime;
}),
"[project]/src/icons/copy.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgCopy = function SvgCopy(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M6.588 4.584a.5.5 0 0 1 .5-.5h8.327a.5.5 0 0 1 .5.5v8.329a.5.5 0 0 1-.5.5H7.088a.5.5 0 0 1-.5-.5zm.5-2a2 2 0 0 0-2 2v.51h-.503a2 2 0 0 0-2 2v8.322a2 2 0 0 0 2 2h8.322a2 2 0 0 0 2-2v-.503h.508a2 2 0 0 0 2-2V4.584a2 2 0 0 0-2-2zm6.319 12.329H7.088a2 2 0 0 1-2-2V6.594h-.503a.5.5 0 0 0-.5.5v8.322a.5.5 0 0 0 .5.5h8.322a.5.5 0 0 0 .5-.5z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgCopy;
}),
"[project]/src/icons/chevron-left.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgChevronLeft = function SvgChevronLeft(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        stroke: "currentColor",
        strokeLinecap: "round",
        strokeLinejoin: "round",
        strokeWidth: 1.5,
        d: "M12.708 5 7.5 10.208l5.208 5.209"
    })));
};
const __TURBOPACK__default__export__ = SvgChevronLeft;
}),
"[project]/src/icons/user-circle.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgUserCircle = function SvgUserCircle(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M12 3.5a8.5 8.5 0 0 0-6.38 14.116 5.25 5.25 0 0 1 5.105-4.02h2.55a5.25 5.25 0 0 1 5.105 4.02A8.5 8.5 0 0 0 12 3.5m5.025 15.357v-.011a3.75 3.75 0 0 0-3.75-3.75h-2.55a3.75 3.75 0 0 0-3.75 3.75v.01A8.46 8.46 0 0 0 12 20.5c1.88 0 3.617-.61 5.025-1.643M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10-4.477 10-10 10S2 17.523 2 12m10-4.75a2.018 2.018 0 1 0 0 4.036 2.018 2.018 0 0 0 0-4.036M8.48 9.268a3.518 3.518 0 1 1 7.036 0 3.518 3.518 0 0 1-7.036 0",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgUserCircle;
}),
"[project]/src/icons/task-icon.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgTaskIcon = function SvgTaskIcon(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M7.756 5.501a.75.75 0 0 1 .75-.75h9.993a.75.75 0 0 1 .75.75v9.995a.75.75 0 0 1-.75.75H8.506a.75.75 0 0 1-.75-.75zm.75-2.25a2.25 2.25 0 0 0-2.25 2.25v.762h-.754a2.25 2.25 0 0 0-2.25 2.25V18.5a2.25 2.25 0 0 0 2.25 2.25h9.986a2.25 2.25 0 0 0 2.25-2.25v-.754h.76a2.25 2.25 0 0 0 2.25-2.25V5.5a2.25 2.25 0 0 0-2.25-2.25zm7.732 14.495H8.506a2.25 2.25 0 0 1-2.25-2.25V7.763h-.754a.75.75 0 0 0-.75.75V18.5c0 .414.336.75.75.75h9.986a.75.75 0 0 0 .75-.75z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgTaskIcon;
}),
"[project]/src/icons/list.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgList = function SvgList(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M5.5 3.25A2.25 2.25 0 0 0 3.25 5.5v13a2.25 2.25 0 0 0 2.25 2.25h13a2.25 2.25 0 0 0 2.25-2.25v-13a2.25 2.25 0 0 0-2.25-2.25zM4.75 5.5a.75.75 0 0 1 .75-.75h13a.75.75 0 0 1 .75.75v13a.75.75 0 0 1-.75.75h-13a.75.75 0 0 1-.75-.75zm1.5 4.214a.75.75 0 0 1 .75-.75h10a.75.75 0 1 1 0 1.5H7a.75.75 0 0 1-.75-.75m0 4.572a.75.75 0 0 1 .75-.75h10a.75.75 0 1 1 0 1.5H7a.75.75 0 0 1-.75-.75",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgList;
}),
"[project]/src/icons/table.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgTable = function SvgTable(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M3.25 5.5A2.25 2.25 0 0 1 5.5 3.25h13a2.25 2.25 0 0 1 2.25 2.25v13a2.25 2.25 0 0 1-2.25 2.25h-13a2.25 2.25 0 0 1-2.25-2.25zm2.25-.75a.75.75 0 0 0-.75.75v3.083h14.5V5.5a.75.75 0 0 0-.75-.75zm13.75 5.333h-3.834v3.833h3.834zm-5.334 0h-3.833v3.833h3.833zm-5.333 0H4.75v3.833h3.833zM4.75 18.5v-3.084h3.833v3.834H5.5a.75.75 0 0 1-.75-.75m5.333.75v-3.834h3.833v3.834zm5.333 0v-3.834h3.834V18.5a.75.75 0 0 1-.75.75z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgTable;
}),
"[project]/src/icons/page.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgPage = function SvgPage(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M8.504 4.25a.75.75 0 0 1 .75-.75h6.024a.75.75 0 0 1 .53.22l2.473 2.472c.14.141.22.332.22.53V16.75a.75.75 0 0 1-.75.75H9.253a.75.75 0 0 1-.75-.75zM14.748 19H9.254a2.25 2.25 0 0 1-2.25-2.25V6.499h-.756a.75.75 0 0 0-.75.75V19.75c0 .414.336.75.75.75h7.75a.75.75 0 0 0 .75-.75zM7.004 4.999V4.25A2.25 2.25 0 0 1 9.254 2h6.024c.596 0 1.169.237 1.59.659l2.473 2.473c.422.422.66.994.66 1.59V16.75A2.25 2.25 0 0 1 17.75 19h-1.503v.75a2.25 2.25 0 0 1-2.25 2.25h-7.75a2.25 2.25 0 0 1-2.25-2.25V7.249a2.25 2.25 0 0 1 2.25-2.25z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgPage;
}),
"[project]/src/icons/pie-chart.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgPieChart = function SvgPieChart(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M12 2a.75.75 0 0 0-.75.75V12c0 .414.336.75.75.75h9.25A.75.75 0 0 0 22 12c0-5.523-4.477-10-10-10m.75 9.25V3.533a8.492 8.492 0 0 1 5.26 2.457 8.5 8.5 0 0 1 2.457 5.26zM2 12c0-4.75 3.31-8.725 7.75-9.746v1.547A8.5 8.5 0 1 0 20.199 14.25h1.547C20.726 18.69 16.749 22 12 22 6.477 22 2 17.523 2 12",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgPieChart;
}),
"[project]/src/icons/box-cube.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgBoxCube = function SvgBoxCube(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M11.665 3.756a.75.75 0 0 1 .67 0l6.446 3.223-6.445 3.222a.75.75 0 0 1-.671 0L5.22 6.979zM4.293 8.192v7.903c0 .284.16.543.415.67l6.542 3.271v-8.385a2 2 0 0 1-.256-.108zm8.457 11.845 6.543-3.272a.75.75 0 0 0 .415-.67V8.192l-6.701 3.35q-.126.063-.257.11zm.257-17.622a2.25 2.25 0 0 0-2.013 0L4.037 5.893a2.25 2.25 0 0 0-1.244 2.013v8.189a2.25 2.25 0 0 0 1.244 2.012l6.957 3.479.336-.671-.336.67a2.25 2.25 0 0 0 2.013 0l6.957-3.478a2.25 2.25 0 0 0 1.244-2.012v-8.19a2.25 2.25 0 0 0-1.244-2.012z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgBoxCube;
}),
"[project]/src/icons/plug-in.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgPlugIn = function SvgPlugIn(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M14 2.75a.75.75 0 0 1 1.5 0v2.983H19a.75.75 0 0 1 0 1.5h-.5v5a6.5 6.5 0 0 1-5.75 6.457v2.56a.75.75 0 0 1-1.5 0v-2.56a6.5 6.5 0 0 1-5.75-6.457v-5H5a.75.75 0 0 1 0-1.5h3.5V2.75a.75.75 0 0 1 1.5 0v2.983h4zM7 7.233v5a5 5 0 0 0 10 0v-5z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgPlugIn;
}),
"[project]/src/icons/docs.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgDocs = function SvgDocs(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M19.5 19.75A2.25 2.25 0 0 1 17.25 22H6.75a2.25 2.25 0 0 1-2.25-2.25V9.621c0-.596.237-1.169.659-1.59l5.367-5.371A2.25 2.25 0 0 1 12.118 2h5.132a2.25 2.25 0 0 1 2.25 2.25zm-2.25.75a.75.75 0 0 0 .75-.75V4.25a.75.75 0 0 0-.75-.75h-5.002l.003 4A2.25 2.25 0 0 1 10 9.75H6v10c0 .414.336.75.75.75zM7.06 8.25l3.689-3.691.002 2.941a.75.75 0 0 1-.75.75zm1.19 6.25a.75.75 0 0 1 .75-.75h6a.75.75 0 0 1 0 1.5H9a.75.75 0 0 1-.75-.75m0 3a.75.75 0 0 1 .75-.75h3a.75.75 0 0 1 0 1.5H9a.75.75 0 0 1-.75-.75",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgDocs;
}),
"[project]/src/icons/mail-line.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgMailLine = function SvgMailLine(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M3.5 8.187v9.063c0 .414.336.75.75.75h15.5a.75.75 0 0 0 .75-.75V8.187l-7.213 5.03c-.773.54-1.8.54-2.574 0zm17-1.958v.015a.24.24 0 0 1-.1.185l-7.97 5.558a.75.75 0 0 1-.859 0l-7.97-5.558A.236.236 0 0 1 3.736 6h16.528c.128 0 .232.102.236.229m1.5.027V17.25a2.25 2.25 0 0 1-2.25 2.25H4.25A2.25 2.25 0 0 1 2 17.25V6.204A1.736 1.736 0 0 1 3.737 4.5h16.528c.959 0 1.736.777 1.736 1.735z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgMailLine;
}),
"[project]/src/icons/horizontal-dots.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgHorizontalDots = function SvgHorizontalDots(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M6 10.245c.966 0 1.75.784 1.75 1.75v.01a1.75 1.75 0 0 1-3.5 0v-.01c0-.966.783-1.75 1.75-1.75m12 0c.966 0 1.75.784 1.75 1.75v.01a1.75 1.75 0 1 1-3.5 0v-.01c0-.966.783-1.75 1.75-1.75m-4.25 1.75a1.75 1.75 0 1 0-3.5 0v.01a1.75 1.75 0 1 0 3.5 0z",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgHorizontalDots;
}),
"[project]/src/icons/chat.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgChat = function SvgChat(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        fillRule: "evenodd",
        d: "M4 12.096a8 8 0 1 1 8 8H5.06l1.283-1.283a.75.75 0 0 0 0-1.06A7.97 7.97 0 0 1 4 12.096m8-9.5a9.5 9.5 0 0 0-7.227 15.666L2.72 20.315a.75.75 0 0 0 .53 1.28H12a9.5 9.5 0 0 0 0-19m-4.375 8.25a1.25 1.25 0 1 0 0 2.5 1.25 1.25 0 0 0 0-2.5m3.125 1.25a1.25 1.25 0 1 1 1.25 1.25c-.69 0-1.25-.559-1.25-1.25m5.625-1.25a1.25 1.25 0 0 0 0 2.5 1.25 1.25 0 0 0 0-2.5",
        clipRule: "evenodd"
    })));
};
const __TURBOPACK__default__export__ = SvgChat;
}),
"[project]/src/icons/more-dot.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgMoreDot = function SvgMoreDot(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 24,
        height: 24,
        fill: "none"
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "currentColor",
        d: "M10.244 6c0-.966.784-1.75 1.75-1.75h.01a1.75 1.75 0 1 1 0 3.5h-.01A1.75 1.75 0 0 1 10.244 6m0 12c0-.966.784-1.75 1.75-1.75h.01a1.75 1.75 0 1 1 0 3.5h-.01a1.75 1.75 0 0 1-1.75-1.75m1.75-7.75a1.75 1.75 0 1 0 0 3.5h.01a1.75 1.75 0 1 0 0-3.5z"
    })));
};
const __TURBOPACK__default__export__ = SvgMoreDot;
}),
"[project]/src/icons/bell.svg.js [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var _path;
function _extends() {
    return _extends = ("TURBOPACK compile-time truthy", 1) ? Object.assign.bind() : "TURBOPACK unreachable", _extends.apply(null, arguments);
}
;
var SvgBell = function SvgBell(props) {
    return /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("svg", _extends({
        xmlns: "http://www.w3.org/2000/svg",
        width: 20,
        height: 20
    }, props), _path || (_path = /*#__PURE__*/ __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["createElement"]("path", {
        fill: "none",
        d: "M10.75 2.292a.75.75 0 1 0-1.5 0v.544a6.376 6.376 0 0 0-5.625 6.331v5.292h-.292a.75.75 0 0 0 0 1.5h13.334a.75.75 0 1 0 0-1.5h-.292V9.167a6.376 6.376 0 0 0-5.625-6.33zm4.125 12.167V9.167a4.875 4.875 0 1 0-9.75 0v5.292zM8 17.71c0 .414.336.75.75.75h2.5a.75.75 0 1 0 0-1.5h-2.5a.75.75 0 0 0-.75.75"
    })));
};
const __TURBOPACK__default__export__ = SvgBell;
}),
"[project]/src/icons/index.tsx [app-ssr] (ecmascript) <locals>", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([]);
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$plus$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/plus.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$close$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/close.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/box.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$check$2d$circle$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/check-circle.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$alert$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/alert.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$info$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/info.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$info$2d$hexa$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/info-hexa.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$bolt$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/bolt.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$arrow$2d$up$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/arrow-up.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$arrow$2d$down$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/arrow-down.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$folder$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/folder.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$videos$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/videos.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$audio$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/audio.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$grid$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/grid.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$file$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/file.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$download$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/download.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$arrow$2d$right$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/arrow-right.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$group$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/group.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$line$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/box-line.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$shooting$2d$star$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/shooting-star.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$dollar$2d$line$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/dollar-line.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$trash$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/trash.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$angle$2d$up$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/angle-up.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$angle$2d$down$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/angle-down.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$pencil$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/pencil.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$check$2d$line$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/check-line.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$close$2d$line$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/close-line.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$chevron$2d$down$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/chevron-down.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$chevron$2d$up$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/chevron-up.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$paper$2d$plane$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/paper-plane.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$lock$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/lock.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$envelope$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/envelope.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$user$2d$line$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/user-line.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$calender$2d$line$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/calender-line.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$eye$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/eye.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$eye$2d$close$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/eye-close.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$time$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/time.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$copy$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/copy.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$chevron$2d$left$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/chevron-left.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$user$2d$circle$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/user-circle.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$task$2d$icon$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/task-icon.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$list$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/list.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$table$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/table.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$page$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/page.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$pie$2d$chart$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/pie-chart.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$cube$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/box-cube.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$plug$2d$in$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/plug-in.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$docs$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/docs.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$mail$2d$line$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/mail-line.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$horizontal$2d$dots$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/horizontal-dots.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$chat$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/chat.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$more$2d$dot$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/more-dot.svg.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$bell$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/bell.svg.js [app-ssr] (ecmascript)");
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
;
}),
"[project]/src/icons/box-cube.svg.js [app-ssr] (ecmascript) <export default as BoxCubeIcon>", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "BoxCubeIcon",
    ()=>__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$cube$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"]
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$cube$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/box-cube.svg.js [app-ssr] (ecmascript)");
}),
"[project]/src/icons/chevron-down.svg.js [app-ssr] (ecmascript) <export default as ChevronDownIcon>", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "ChevronDownIcon",
    ()=>__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$chevron$2d$down$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"]
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$chevron$2d$down$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/chevron-down.svg.js [app-ssr] (ecmascript)");
}),
"[project]/src/icons/list.svg.js [app-ssr] (ecmascript) <export default as ListIcon>", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "ListIcon",
    ()=>__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$list$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"]
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$list$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/list.svg.js [app-ssr] (ecmascript)");
}),
"[project]/src/icons/pie-chart.svg.js [app-ssr] (ecmascript) <export default as PieChartIcon>", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "PieChartIcon",
    ()=>__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$pie$2d$chart$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"]
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$pie$2d$chart$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/pie-chart.svg.js [app-ssr] (ecmascript)");
}),
"[project]/src/icons/plug-in.svg.js [app-ssr] (ecmascript) <export default as PlugInIcon>", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "PlugInIcon",
    ()=>__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$plug$2d$in$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"]
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$plug$2d$in$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/icons/plug-in.svg.js [app-ssr] (ecmascript)");
}),
"[project]/src/layout/AppSidebar.tsx [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react-jsx-dev-runtime.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$client$2f$app$2d$dir$2f$link$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/client/app-dir/link.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$image$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/image.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$navigation$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/navigation.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$context$2f$SidebarContext$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/context/SidebarContext.tsx [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$index$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$locals$3e$__ = __turbopack_context__.i("[project]/src/icons/index.tsx [app-ssr] (ecmascript) <locals>");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$cube$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__BoxCubeIcon$3e$__ = __turbopack_context__.i("[project]/src/icons/box-cube.svg.js [app-ssr] (ecmascript) <export default as BoxCubeIcon>");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$chevron$2d$down$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__ChevronDownIcon$3e$__ = __turbopack_context__.i("[project]/src/icons/chevron-down.svg.js [app-ssr] (ecmascript) <export default as ChevronDownIcon>");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$list$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__ListIcon$3e$__ = __turbopack_context__.i("[project]/src/icons/list.svg.js [app-ssr] (ecmascript) <export default as ListIcon>");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$pie$2d$chart$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__PieChartIcon$3e$__ = __turbopack_context__.i("[project]/src/icons/pie-chart.svg.js [app-ssr] (ecmascript) <export default as PieChartIcon>");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$plug$2d$in$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__PlugInIcon$3e$__ = __turbopack_context__.i("[project]/src/icons/plug-in.svg.js [app-ssr] (ecmascript) <export default as PlugInIcon>");
"use client";
;
;
;
;
;
;
;
const navItems = [
    {
        name: "Forms",
        icon: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$list$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__ListIcon$3e$__["ListIcon"], {}, void 0, false, {
            fileName: "[project]/src/layout/AppSidebar.tsx",
            lineNumber: 32,
            columnNumber: 11
        }, ("TURBOPACK compile-time value", void 0)),
        subItems: [
            {
                name: "Form Elements",
                path: "/form-elements",
                pro: false
            }
        ]
    }
];
const othersItems = [
    {
        icon: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$pie$2d$chart$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__PieChartIcon$3e$__["PieChartIcon"], {}, void 0, false, {
            fileName: "[project]/src/layout/AppSidebar.tsx",
            lineNumber: 41,
            columnNumber: 11
        }, ("TURBOPACK compile-time value", void 0)),
        name: "Settings",
        subItems: [
            {
                name: "Users",
                path: "/users",
                pro: false
            },
            {
                name: "Company",
                path: "/Company",
                pro: false
            },
            {
                name: "Branch",
                path: "/Company/Branch",
                pro: false
            }
        ]
    },
    {
        icon: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$cube$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__BoxCubeIcon$3e$__["BoxCubeIcon"], {}, void 0, false, {
            fileName: "[project]/src/layout/AppSidebar.tsx",
            lineNumber: 50,
            columnNumber: 11
        }, ("TURBOPACK compile-time value", void 0)),
        name: "Products",
        subItems: [
            {
                name: "Category",
                path: "/Company/Category",
                pro: false
            },
            {
                name: "Category Type",
                path: "/Company/CategoryType",
                pro: false
            },
            {
                name: "Product",
                path: "/Product",
                pro: false
            }
        ]
    },
    {
        icon: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$cube$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__BoxCubeIcon$3e$__["BoxCubeIcon"], {}, void 0, false, {
            fileName: "[project]/src/layout/AppSidebar.tsx",
            lineNumber: 60,
            columnNumber: 11
        }, ("TURBOPACK compile-time value", void 0)),
        name: "Sales",
        subItems: [
            {
                name: "Customer",
                path: "/Sales",
                pro: false
            },
            {
                name: "Invoices",
                path: "/avatars",
                pro: false
            },
            {
                name: "Sales List",
                path: "/Sales/List",
                pro: false
            },
            {
                name: "Cancelled Sales",
                path: "/buttons",
                pro: false
            },
            {
                name: "Customer Credits",
                path: "/images",
                pro: false
            },
            {
                name: "Payments Received",
                path: "/videos",
                pro: false
            }
        ]
    },
    {
        icon: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$cube$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__BoxCubeIcon$3e$__["BoxCubeIcon"], {}, void 0, false, {
            fileName: "[project]/src/layout/AppSidebar.tsx",
            lineNumber: 72,
            columnNumber: 11
        }, ("TURBOPACK compile-time value", void 0)),
        name: "Inventory",
        subItems: [
            {
                name: "Stock",
                path: "/Inventory",
                pro: false
            },
            {
                name: "Transfer stock",
                path: "/Inventory/Transfer",
                pro: false
            },
            {
                name: "Stock adjustment",
                path: "/buttons",
                pro: false
            },
            {
                name: "Convert stock",
                path: "/Inventory/Convert",
                pro: false
            }
        ]
    },
    {
        icon: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$cube$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__BoxCubeIcon$3e$__["BoxCubeIcon"], {}, void 0, false, {
            fileName: "[project]/src/layout/AppSidebar.tsx",
            lineNumber: 82,
            columnNumber: 9
        }, ("TURBOPACK compile-time value", void 0)),
        name: "Purchases",
        subItems: [
            {
                name: "Suppliers",
                path: "/purchases/suppliers",
                pro: false
            },
            {
                name: "Purchase Orders",
                path: "/purchases/purchase-orders",
                pro: false
            },
            {
                name: "Create Purchase Order",
                path: "/purchases/purchase-orders/create",
                pro: false
            },
            {
                name: "Purchase Order Approval",
                path: "/purchases/purchase-orders/approval",
                pro: false
            },
            {
                name: "Receive Goods",
                path: "/purchases/goods-receipt/receive",
                pro: false
            },
            {
                name: "Goods Receipt List",
                path: "/purchases/goods-receipt",
                pro: false
            },
            {
                name: "Purchase Returns",
                path: "/purchases/purchase-returns",
                pro: false
            }
        ]
    },
    {
        icon: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$box$2d$cube$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__BoxCubeIcon$3e$__["BoxCubeIcon"], {}, void 0, false, {
            fileName: "[project]/src/layout/AppSidebar.tsx",
            lineNumber: 125,
            columnNumber: 11
        }, ("TURBOPACK compile-time value", void 0)),
        name: "Reports",
        subItems: [
            {
                name: "Alerts",
                path: "/alerts",
                pro: false
            },
            {
                name: "Avatar",
                path: "/avatars",
                pro: false
            },
            {
                name: "Badge",
                path: "/badge",
                pro: false
            },
            {
                name: "Buttons",
                path: "/buttons",
                pro: false
            },
            {
                name: "Images",
                path: "/images",
                pro: false
            },
            {
                name: "Videos",
                path: "/videos",
                pro: false
            }
        ]
    },
    {
        icon: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$plug$2d$in$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__PlugInIcon$3e$__["PlugInIcon"], {}, void 0, false, {
            fileName: "[project]/src/layout/AppSidebar.tsx",
            lineNumber: 137,
            columnNumber: 11
        }, ("TURBOPACK compile-time value", void 0)),
        name: "Authentication",
        subItems: [
            {
                name: "Sign In",
                path: "/signin",
                pro: false
            },
            {
                name: "Sign Up",
                path: "/signup",
                pro: false
            }
        ]
    }
];
const AppSidebar = ()=>{
    const { isExpanded, isMobileOpen, isHovered, setIsHovered } = (0, __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$context$2f$SidebarContext$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useSidebar"])();
    const pathname = (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$navigation$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["usePathname"])();
    const renderMenuItems = (navItems, menuType)=>/*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("ul", {
            className: "flex flex-col gap-4",
            children: navItems.map((nav, index)=>/*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("li", {
                    children: [
                        nav.subItems ? /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("button", {
                            onClick: ()=>handleSubmenuToggle(index, menuType),
                            className: `menu-item group  ${openSubmenu?.type === menuType && openSubmenu?.index === index ? "menu-item-active" : "menu-item-inactive"} cursor-pointer ${!isExpanded && !isHovered ? "lg:justify-center" : "lg:justify-start"}`,
                            children: [
                                /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("span", {
                                    className: ` ${openSubmenu?.type === menuType && openSubmenu?.index === index ? "menu-item-icon-active" : "menu-item-icon-inactive"}`,
                                    children: nav.icon
                                }, void 0, false, {
                                    fileName: "[project]/src/layout/AppSidebar.tsx",
                                    lineNumber: 170,
                                    columnNumber: 15
                                }, ("TURBOPACK compile-time value", void 0)),
                                (isExpanded || isHovered || isMobileOpen) && /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("span", {
                                    className: `menu-item-text`,
                                    children: nav.name
                                }, void 0, false, {
                                    fileName: "[project]/src/layout/AppSidebar.tsx",
                                    lineNumber: 180,
                                    columnNumber: 17
                                }, ("TURBOPACK compile-time value", void 0)),
                                (isExpanded || isHovered || isMobileOpen) && /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$icons$2f$chevron$2d$down$2e$svg$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__$3c$export__default__as__ChevronDownIcon$3e$__["ChevronDownIcon"], {
                                    className: `ml-auto w-5 h-5 transition-transform duration-200  ${openSubmenu?.type === menuType && openSubmenu?.index === index ? "rotate-180 text-brand-500" : ""}`
                                }, void 0, false, {
                                    fileName: "[project]/src/layout/AppSidebar.tsx",
                                    lineNumber: 183,
                                    columnNumber: 17
                                }, ("TURBOPACK compile-time value", void 0))
                            ]
                        }, void 0, true, {
                            fileName: "[project]/src/layout/AppSidebar.tsx",
                            lineNumber: 158,
                            columnNumber: 13
                        }, ("TURBOPACK compile-time value", void 0)) : nav.path && /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$client$2f$app$2d$dir$2f$link$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {
                            href: nav.path,
                            className: `menu-item group ${isActive(nav.path) ? "menu-item-active" : "menu-item-inactive"}`,
                            children: [
                                /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("span", {
                                    className: `${isActive(nav.path) ? "menu-item-icon-active" : "menu-item-icon-inactive"}`,
                                    children: nav.icon
                                }, void 0, false, {
                                    fileName: "[project]/src/layout/AppSidebar.tsx",
                                    lineNumber: 201,
                                    columnNumber: 17
                                }, ("TURBOPACK compile-time value", void 0)),
                                (isExpanded || isHovered || isMobileOpen) && /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("span", {
                                    className: `menu-item-text`,
                                    children: nav.name
                                }, void 0, false, {
                                    fileName: "[project]/src/layout/AppSidebar.tsx",
                                    lineNumber: 211,
                                    columnNumber: 19
                                }, ("TURBOPACK compile-time value", void 0))
                            ]
                        }, void 0, true, {
                            fileName: "[project]/src/layout/AppSidebar.tsx",
                            lineNumber: 195,
                            columnNumber: 15
                        }, ("TURBOPACK compile-time value", void 0)),
                        nav.subItems && (isExpanded || isHovered || isMobileOpen) && /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                            ref: (el)=>{
                                subMenuRefs.current[`${menuType}-${index}`] = el;
                            },
                            className: "overflow-hidden transition-all duration-300",
                            style: {
                                height: openSubmenu?.type === menuType && openSubmenu?.index === index ? `${subMenuHeight[`${menuType}-${index}`]}px` : "0px"
                            },
                            children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("ul", {
                                className: "mt-2 space-y-1 ml-9",
                                children: nav.subItems.map((subItem)=>/*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("li", {
                                        children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$client$2f$app$2d$dir$2f$link$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {
                                            href: subItem.path,
                                            className: `menu-dropdown-item ${isActive(subItem.path) ? "menu-dropdown-item-active" : "menu-dropdown-item-inactive"}`,
                                            children: [
                                                subItem.name,
                                                /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("span", {
                                                    className: "flex items-center gap-1 ml-auto",
                                                    children: [
                                                        subItem.new && /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("span", {
                                                            className: `ml-auto ${isActive(subItem.path) ? "menu-dropdown-badge-active" : "menu-dropdown-badge-inactive"} menu-dropdown-badge `,
                                                            children: "new"
                                                        }, void 0, false, {
                                                            fileName: "[project]/src/layout/AppSidebar.tsx",
                                                            lineNumber: 243,
                                                            columnNumber: 27
                                                        }, ("TURBOPACK compile-time value", void 0)),
                                                        subItem.pro && /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("span", {
                                                            className: `ml-auto ${isActive(subItem.path) ? "menu-dropdown-badge-active" : "menu-dropdown-badge-inactive"} menu-dropdown-badge `,
                                                            children: "pro"
                                                        }, void 0, false, {
                                                            fileName: "[project]/src/layout/AppSidebar.tsx",
                                                            lineNumber: 254,
                                                            columnNumber: 27
                                                        }, ("TURBOPACK compile-time value", void 0))
                                                    ]
                                                }, void 0, true, {
                                                    fileName: "[project]/src/layout/AppSidebar.tsx",
                                                    lineNumber: 241,
                                                    columnNumber: 23
                                                }, ("TURBOPACK compile-time value", void 0))
                                            ]
                                        }, void 0, true, {
                                            fileName: "[project]/src/layout/AppSidebar.tsx",
                                            lineNumber: 232,
                                            columnNumber: 21
                                        }, ("TURBOPACK compile-time value", void 0))
                                    }, subItem.name, false, {
                                        fileName: "[project]/src/layout/AppSidebar.tsx",
                                        lineNumber: 231,
                                        columnNumber: 19
                                    }, ("TURBOPACK compile-time value", void 0)))
                            }, void 0, false, {
                                fileName: "[project]/src/layout/AppSidebar.tsx",
                                lineNumber: 229,
                                columnNumber: 15
                            }, ("TURBOPACK compile-time value", void 0))
                        }, void 0, false, {
                            fileName: "[project]/src/layout/AppSidebar.tsx",
                            lineNumber: 217,
                            columnNumber: 13
                        }, ("TURBOPACK compile-time value", void 0))
                    ]
                }, nav.name, true, {
                    fileName: "[project]/src/layout/AppSidebar.tsx",
                    lineNumber: 156,
                    columnNumber: 9
                }, ("TURBOPACK compile-time value", void 0)))
        }, void 0, false, {
            fileName: "[project]/src/layout/AppSidebar.tsx",
            lineNumber: 154,
            columnNumber: 5
        }, ("TURBOPACK compile-time value", void 0));
    const [openSubmenu, setOpenSubmenu] = (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useState"])(null);
    const [subMenuHeight, setSubMenuHeight] = (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useState"])({});
    const subMenuRefs = (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useRef"])({});
    // const isActive = (path: string) => path === pathname;
    const isActive = (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useCallback"])((path)=>path === pathname, [
        pathname
    ]);
    (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useEffect"])(()=>{
        // Check if the current path matches any submenu item
        let submenuMatched = false;
        [
            "main",
            "others"
        ].forEach((menuType)=>{
            const items = menuType === "main" ? navItems : othersItems;
            items.forEach((nav, index)=>{
                if (nav.subItems) {
                    nav.subItems.forEach((subItem)=>{
                        if (isActive(subItem.path)) {
                            setOpenSubmenu({
                                type: menuType,
                                index
                            });
                            submenuMatched = true;
                        }
                    });
                }
            });
        });
        // If no submenu item matches, close the open submenu
        if (!submenuMatched) {
            setOpenSubmenu(null);
        }
    }, [
        pathname,
        isActive
    ]);
    (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useEffect"])(()=>{
        // Set the height of the submenu items when the submenu is opened
        if (openSubmenu !== null) {
            const key = `${openSubmenu.type}-${openSubmenu.index}`;
            if (subMenuRefs.current[key]) {
                setSubMenuHeight((prevHeights)=>({
                        ...prevHeights,
                        [key]: subMenuRefs.current[key]?.scrollHeight || 0
                    }));
            }
        }
    }, [
        openSubmenu
    ]);
    const handleSubmenuToggle = (index, menuType)=>{
        setOpenSubmenu((prevOpenSubmenu)=>{
            if (prevOpenSubmenu && prevOpenSubmenu.type === menuType && prevOpenSubmenu.index === index) {
                return null;
            }
            return {
                type: menuType,
                index
            };
        });
    };
    return /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("aside", {
        className: `fixed mt-16 flex flex-col lg:mt-0 top-0 px-5 left-0 bg-white dark:bg-gray-900 dark:border-gray-800 text-gray-900 h-screen transition-all duration-300 ease-in-out z-50 border-r border-gray-200 
        ${isExpanded || isMobileOpen ? "w-[290px]" : isHovered ? "w-[290px]" : "w-[90px]"}
        ${isMobileOpen ? "translate-x-0" : "-translate-x-full"}
        lg:translate-x-0`,
        onMouseEnter: ()=>!isExpanded && setIsHovered(true),
        onMouseLeave: ()=>setIsHovered(false),
        children: [
            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                className: `py-8 flex  ${!isExpanded && !isHovered ? "lg:justify-center" : "justify-start"}`,
                children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$client$2f$app$2d$dir$2f$link$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {
                    href: "/",
                    children: isExpanded || isHovered || isMobileOpen ? /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["Fragment"], {
                        children: [
                            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$image$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {
                                className: "dark:hidden",
                                src: "/images/logo/logo.svg",
                                alt: "Logo",
                                width: 150,
                                height: 40
                            }, void 0, false, {
                                fileName: "[project]/src/layout/AppSidebar.tsx",
                                lineNumber: 363,
                                columnNumber: 15
                            }, ("TURBOPACK compile-time value", void 0)),
                            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$image$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {
                                className: "hidden dark:block",
                                src: "/images/logo/logo-dark.svg",
                                alt: "Logo",
                                width: 150,
                                height: 40
                            }, void 0, false, {
                                fileName: "[project]/src/layout/AppSidebar.tsx",
                                lineNumber: 370,
                                columnNumber: 15
                            }, ("TURBOPACK compile-time value", void 0))
                        ]
                    }, void 0, true) : /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$image$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {
                        src: "/images/logo/logo-icon.svg",
                        alt: "Logo",
                        width: 32,
                        height: 32
                    }, void 0, false, {
                        fileName: "[project]/src/layout/AppSidebar.tsx",
                        lineNumber: 379,
                        columnNumber: 13
                    }, ("TURBOPACK compile-time value", void 0))
                }, void 0, false, {
                    fileName: "[project]/src/layout/AppSidebar.tsx",
                    lineNumber: 360,
                    columnNumber: 9
                }, ("TURBOPACK compile-time value", void 0))
            }, void 0, false, {
                fileName: "[project]/src/layout/AppSidebar.tsx",
                lineNumber: 355,
                columnNumber: 7
            }, ("TURBOPACK compile-time value", void 0)),
            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                className: "flex flex-col overflow-y-auto duration-300 ease-linear no-scrollbar",
                children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("nav", {
                    className: "mb-6",
                    children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                        className: "flex flex-col gap-4",
                        children: /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                            children: [
                                /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("h2", {
                                    className: `mb-4 text-xs uppercase flex leading-[20px] text-gray-400 ${!isExpanded && !isHovered ? "lg:justify-center" : "justify-start"}`
                                }, void 0, false, {
                                    fileName: "[project]/src/layout/AppSidebar.tsx",
                                    lineNumber: 392,
                                    columnNumber: 15
                                }, ("TURBOPACK compile-time value", void 0)),
                                renderMenuItems(othersItems, "others")
                            ]
                        }, void 0, true, {
                            fileName: "[project]/src/layout/AppSidebar.tsx",
                            lineNumber: 391,
                            columnNumber: 13
                        }, ("TURBOPACK compile-time value", void 0))
                    }, void 0, false, {
                        fileName: "[project]/src/layout/AppSidebar.tsx",
                        lineNumber: 390,
                        columnNumber: 11
                    }, ("TURBOPACK compile-time value", void 0))
                }, void 0, false, {
                    fileName: "[project]/src/layout/AppSidebar.tsx",
                    lineNumber: 389,
                    columnNumber: 9
                }, ("TURBOPACK compile-time value", void 0))
            }, void 0, false, {
                fileName: "[project]/src/layout/AppSidebar.tsx",
                lineNumber: 388,
                columnNumber: 7
            }, ("TURBOPACK compile-time value", void 0))
        ]
    }, void 0, true, {
        fileName: "[project]/src/layout/AppSidebar.tsx",
        lineNumber: 341,
        columnNumber: 5
    }, ("TURBOPACK compile-time value", void 0));
};
const __TURBOPACK__default__export__ = AppSidebar;
}),
"[project]/src/layout/Backdrop.tsx [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>__TURBOPACK__default__export__
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react-jsx-dev-runtime.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$context$2f$SidebarContext$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/context/SidebarContext.tsx [app-ssr] (ecmascript)");
;
;
const Backdrop = ()=>{
    const { isMobileOpen, toggleMobileSidebar } = (0, __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$context$2f$SidebarContext$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useSidebar"])();
    if (!isMobileOpen) return null;
    return /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
        className: "fixed inset-0 z-40 bg-gray-900/50 lg:hidden",
        onClick: toggleMobileSidebar
    }, void 0, false, {
        fileName: "[project]/src/layout/Backdrop.tsx",
        lineNumber: 10,
        columnNumber: 5
    }, ("TURBOPACK compile-time value", void 0));
};
const __TURBOPACK__default__export__ = Backdrop;
}),
"[project]/src/app/(admin)/layout.tsx [app-ssr] (ecmascript)", ((__turbopack_context__) => {
"use strict";

__turbopack_context__.s([
    "default",
    ()=>AdminLayout
]);
var __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/node_modules/next/dist/server/route-modules/app-page/vendored/ssr/react-jsx-dev-runtime.js [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$context$2f$SidebarContext$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/context/SidebarContext.tsx [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$layout$2f$AppHeader$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/layout/AppHeader.tsx [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$layout$2f$AppSidebar$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/layout/AppSidebar.tsx [app-ssr] (ecmascript)");
var __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$layout$2f$Backdrop$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__ = __turbopack_context__.i("[project]/src/layout/Backdrop.tsx [app-ssr] (ecmascript)");
"use client";
;
;
;
;
;
function AdminLayout({ children }) {
    const { isExpanded, isHovered, isMobileOpen } = (0, __TURBOPACK__imported__module__$5b$project$5d2f$src$2f$context$2f$SidebarContext$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["useSidebar"])();
    // Dynamic class for main content margin based on sidebar state
    const mainContentMargin = isMobileOpen ? "ml-0" : isExpanded || isHovered ? "lg:ml-[290px]" : "lg:ml-[90px]";
    return /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
        className: "min-h-screen xl:flex",
        children: [
            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$layout$2f$AppSidebar$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {}, void 0, false, {
                fileName: "[project]/src/app/(admin)/layout.tsx",
                lineNumber: 26,
                columnNumber: 7
            }, this),
            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$layout$2f$Backdrop$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {}, void 0, false, {
                fileName: "[project]/src/app/(admin)/layout.tsx",
                lineNumber: 27,
                columnNumber: 7
            }, this),
            /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                className: `flex-1 transition-all  duration-300 ease-in-out ${mainContentMargin}`,
                children: [
                    /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])(__TURBOPACK__imported__module__$5b$project$5d2f$src$2f$layout$2f$AppHeader$2e$tsx__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["default"], {}, void 0, false, {
                        fileName: "[project]/src/app/(admin)/layout.tsx",
                        lineNumber: 33,
                        columnNumber: 9
                    }, this),
                    /*#__PURE__*/ (0, __TURBOPACK__imported__module__$5b$project$5d2f$node_modules$2f$next$2f$dist$2f$server$2f$route$2d$modules$2f$app$2d$page$2f$vendored$2f$ssr$2f$react$2d$jsx$2d$dev$2d$runtime$2e$js__$5b$app$2d$ssr$5d$__$28$ecmascript$29$__["jsxDEV"])("div", {
                        className: "p-4 mx-auto max-w-(--breakpoint-2xl) md:p-6",
                        children: children
                    }, void 0, false, {
                        fileName: "[project]/src/app/(admin)/layout.tsx",
                        lineNumber: 35,
                        columnNumber: 9
                    }, this)
                ]
            }, void 0, true, {
                fileName: "[project]/src/app/(admin)/layout.tsx",
                lineNumber: 29,
                columnNumber: 7
            }, this)
        ]
    }, void 0, true, {
        fileName: "[project]/src/app/(admin)/layout.tsx",
        lineNumber: 24,
        columnNumber: 5
    }, this);
}
}),
];

//# sourceMappingURL=%5Broot-of-the-server%5D__280e16d9._.js.map