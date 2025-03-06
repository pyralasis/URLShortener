import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { BrowserRouter, Route, Routes } from 'react-router'
import Info from './Info.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path='/info/:url?' element={<Info />}></Route>
        <Route path='/go/:url?' element={<Info />}></Route>
        <Route path="/" element={<App />}></Route>
      </Routes>
    </BrowserRouter>
  </StrictMode>,
)
