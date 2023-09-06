export default {
  // Global styles apply to _all_ inputs with matching section keys
  global: {
    fieldset: "max-w-md border border-gray-200 rounded px-2 pb-1",
    help: "text-xs text-gray-500",
    inner:
      "formkit-disabled:bg-gray-200 formkit-disabled:cursor-not-allowed formkit-disabled:pointer-events-none",
    input: "appearance-none bg-transparent focus:outline-none focus:ring-0 focus:shadow-none",
    label: "block mb-1 font-medium text-sm text-gray-700",
    legend: "font-medium text-sm text-gray-700",
    loaderIcon: "inline-flex items-center w-4 text-gray-600 animate-spin",
    message: "text-error-500 mb-1 text-xs",
    messages: "list-none p-0 mt-1 mb-0",
    outer: "mb-4 formkit-disabled:opacity-50",
    prefixIcon:
      "w-10 flex self-stretch grow-0 shrink-0 rounded-tl rounded-bl border-r border-gray-400 bg-white bg-gradient-to-b from-transparent to-gray-200 [&>svg]:w-full [&>svg]:max-w-[1em] [&>svg]:max-h-[1em] [&>svg]:m-auto",
    suffixIcon:
      "w-7 pr-3 p-3 flex self-stretch grow-0 shrink-0 [&>svg]:w-full [&>svg]:max-w-[1em] [&>svg]:max-h-[1em] [&>svg]:m-auto",
  },

  // Family styles apply to all inputs that share a common family
  "family:box": {
    decorator:
      "block relative h-5 w-5 mr-2 rounded bg-white bg-gradient-to-b from-transparent to-gray-200 ring-1 ring-gray-200 peer-checked:ring-primary-500 text-transparent peer-checked:text-primary-500",
    decoratorIcon: "flex p-[3px] w-full h-full absolute top-1/2 left-1/2 -translate-y-1/2 -translate-x-1/2",
    help: "mb-2 mt-1.5",
    input: "absolute w-0 h-0 overflow-hidden opacity-0 pointer-events-none peer",
    inner: "$remove:formkit-disabled:bg-gray-200",
    label: "$reset text-sm text-gray-700 mt-1 select-none",
    wrapper: "flex items-center mb-1",
  },
  "family:button": {
    input:
      "$reset focus-visible:ring-ring inline-flex h-10 items-center justify-center rounded-lg bg-primary-600 px-4 py-2.5 text-sm font-semibold text-white shadow-xs transition-colors hover:bg-primary-700 focus-visible:outline-none focus-visible:ring-1 formkit-disabled:pointer-events-none formkit-disabled:opacity-50 formkit-loading:before:mr-2 formkit-loading:before:h-4 formkit-loading:before:w-4 formkit-loading:before:animate-spin formkit-loading:before:rounded-3xl formkit-loading:before:border formkit-loading:before:border-2 formkit-loading:before:border-white formkit-loading:before:border-r-transparent",
    wrapper: "mb-1",
    prefixIcon: "$reset block w-4 -ml-2 mr-2 stretch",
    suffixIcon: "$reset block w-4 ml-2 stretch",
  },
  "family:dropdown": {
    dropdownWrapper: "my-2 w-full shadow-lg rounded [&::-webkit-scrollbar]:hidden",
    emptyMessageInner:
      "flex items-center justify-center text-sm p-2 text-center w-full text-gray-500 [&>span]:mr-3 [&>span]:ml-0",
    inner:
      "max-w-md relative flex ring-1 ring-gray-200 focus-within:ring-primary-500 focus-within:ring-2 rounded-md mb-1 formkit-disabled:focus-within:ring-gray-400 formkit-disabled:focus-within:ring-1 [&>span:first-child]:focus-within:text-primary-500",
    input: "w-full px-3 py-2 text-sm",
    listbox: "bg-white shadow-lg rounded overflow-hidden",
    listboxButton: "flex w-12 self-stretch justify-center mx-auto",
    listitem:
      'pl-7 relative flex px-2 py-1.5 text-sm text-gray-900 hover:bg-gray-50 hover:text-gray-900 data-[is-active="true"]:bg-gray-50 data-[is-active="true"]:text-gray-900 aria-selected:bg-primary aria-selected:text-white data-[disabled]:pointer-events-none data-[disabled]:opacity-50',
    loaderIcon: "ml-auto",
    loadMoreInner:
      "flex items-center justify-center text-sm p-2 text-center w-full text-primary-500 formkit-loading:text-gray-500 cursor-pointer [&>span]:mr-3 [&>span]:ml-0",
    option: "p-2.5",
    optionLoading: "text-gray-500",
    placeholder: "p-2.5 text-gray-500",
    selector: "flex h-10 w-full justify-between items-center text-sm [&u]",
    selectedIcon: "block absolute top-1/2 left-2 w-3 -translate-y-1/2",
    selectIcon: "flex box-content w-4 px-2 self-stretch grow-0 text-gray-500 shrink-0 [&>svg]:w-[1em]",
  },
  "family:text": {
    inner:
      "flex items-center max-w-md ring-1 ring-gray-200 focus-within:ring-primary-500 focus-within:ring-2 [&>label:first-child]:focus-within:text-primary-500 rounded-md mb-1",
    input: "w-full h-10 px-3 py-2 border-none text-sm text-gray-900 placeholder-gray-500",
  },

  // Specific styles apply only to a given input type
  select: {
    inner:
      "flex relative max-w-md items-center rounded mb-1 ring-1 ring-gray-400 focus-within:ring-primary-500 focus-within:ring-2 [&>span:first-child]:focus-within:text-primary-500",
    input:
      'w-full pl-3 pr-8 py-2 border-none text-base text-gray-700 placeholder-gray-500 formkit-multiple:p-0 data-[placeholder="true"]:text-gray-400 formkit-multiple:data-[placeholder="true"]:text-inherit',
    selectIcon: "flex p-[3px] shrink-0 w-5 mr-2 -ml-[1.5em] h-full pointer-events-none [&>svg]:w-[1em]",
    option: "formkit-multiple:p-3 formkit-multiple:text-sm text-gray-700",
  },

  // PRO input styles
  autocomplete: {
    closeIcon: "block grow-0 shrink-0 w-3 mr-3.5",
    inner: "[&>div>[data-value]]:absolute [&>div>[data-value]]:mb-0",
    option: "grow text-ellipsis",
    selection: "static flex left-0 top-0 right-0 bottom-0 mt-0 mb-2 rounded bg-gray-100",
  },
  repeater: {
    content: "grow p-3 flex flex-col align-center",
    controlLabel: "absolute opacity-0 pointer-events-none",
    controls: "flex flex-col items-center justify-center bg-gray-50 p-3",
    downControl: "hover:text-gray-700 disabled:hover:text-inherit disabled:opacity-25",
    fieldset: "py-4 px-5",
    help: "mb-2 mt-1.5",
    item: "flex w-full mb-1 rounded border border-gray-200",
    removeControl:
      "text-gray-500 hover:text-gray-700 disabled:hover:text-inherit disabled:opacity-25 disabled:cursor-not-allowed",
    removeIcon: "block w-5 my-1",
  },
};
