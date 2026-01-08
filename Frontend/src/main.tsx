import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import "./styles/index.css";
import App from './app/App.tsx'
import { Toaster } from "react-hot-toast";

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <App />
     <Toaster position="top-right" reverseOrder={false} />
  </StrictMode>,
)
