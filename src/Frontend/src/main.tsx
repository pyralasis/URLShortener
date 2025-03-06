import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { BrowserRouter, Route, Routes } from 'react-router'
import Info from './Info.tsx'

createRoot(document.getElementById('root')!).render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}></Route>
      <Route path='/info/' element={<Info />}></Route>
      <Route path='/go/' element={<Info />}></Route>
    </Routes>
  </BrowserRouter>
)
