function e(e){const n=e.target;if(function(e){return-1!==t.indexOf(e.getAttribute("type"))}(n)){const e=function(e){const t=e.value,n=e.type;switch(n){case"date":case"month":case"week":return t;case"datetime-local":return 16===t.length?t+":00":t;case"time":return 5===t.length?t+":00":t}throw new Error(`Invalid element type '${n}'.`)}(n);return{value:e}}if(function(e){return e instanceof HTMLSelectElement&&"select-multiple"===e.type}(n)){const e=n;return{value:Array.from(e.options).filter((e=>e.selected)).map((e=>e.value))}}{const e=function(e){return!!e&&"INPUT"===e.tagName&&"checkbox"===e.getAttribute("type")}(n);return{value:e?!!n.checked:n.value}}}const t=["date","datetime-local","month","time","week"];function n(t,n,a){if(!t||!(t instanceof HTMLInputElement||t instanceof HTMLTextAreaElement))return;let o,r,i=!1;t.addEventListener("compositionstart",(e=>{i=!0,r=t.value})),t.addEventListener("compositionend",(a=>{i=!1;const o=e(a);o.value=r+a.data,-1!==t.maxLength&&o.value.length>t.maxLength&&(o.value=o.value.substring(0,t.maxLength)),r=null,n.invokeMethodAsync("Invoke",o)})),t.addEventListener("input",(t=>{if(!i){var r=e(t);clearTimeout(o),o=setTimeout((()=>{n.invokeMethodAsync("Invoke",r)}),a)}}))}function a(e,t){e.value=t}export{n as registerInputEvents,a as setValue};
//# sourceMappingURL=input.js.map